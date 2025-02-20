using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// IniParser class.
/// </summary>
public class IniParser : IIniParser
{
    /// <summary>
    /// Section key pair/value dictionary.
    /// </summary>
    private readonly Dictionary<SectionKeyPair, string> keyPairs;

    /// <summary>
    /// Initializes a new instance of the <see cref="IniParser"/> class.
    /// </summary>
    /// <exception cref="FileNotFoundException">Thrown when the provided ini file path doesnt exist.</exception>
    public IniParser(string iniFilePath)
    {
        if (!File.Exists(iniFilePath))
        {
            throw new FileNotFoundException(nameof(iniFilePath));
        }

        keyPairs = new Dictionary<SectionKeyPair, string>();
        IniFilePath = iniFilePath;
        EnumerateSectionKeyPairs();
    }

    /// <summary>
    /// Gets a value indicating whether <see cref="SaveIni"/> method should be called automatically after changes have been made.
    /// </summary>
    public bool IniAutoSaveEnabled { get; private set; }

    /// <summary>
    /// Gets the source ini file full path.
    /// </summary>
    public string IniFilePath { get; }

    /// <summary>
    /// Gets a value indicating whether changes have been made.
    /// </summary>
    public bool ChangesPending { get; private set; }

    /// <summary>
    /// Returns the value for the given section key. Returns null, if key doesn't exist.
    /// </summary>
    public string? GetValue(string section, string sectionKey)
    {
        SectionKeyPair skp = new SectionKeyPair(section, sectionKey);

        if (keyPairs.TryGetValue(skp, out string keyValue))
        {
            return keyValue;
        }

        return null;
    }

    /// <summary>
    /// Adds/replaces a key value for given section.
    /// </summary>
    public void SetValue(string section, string sectionKey, string keyValue)
    {
        SectionKeyPair skp = new SectionKeyPair(section, sectionKey);

        if (keyPairs.ContainsKey(skp))
        {
            // replace existing key value
            keyPairs[skp] = keyValue.Trim();
        }
        else
        {
            keyPairs.Add(skp, keyValue.Trim());
        }

        ChangesPending = true;
        CheckAutoSaveRequired();
    }

    /// <summary>
    /// Gets keys and their values for given section.
    /// </summary>
    public Dictionary<string, string?> GetSectionKeysAndValues(string section)
    {
        Dictionary<string, string> keysAndValues = new Dictionary<string, string?>();

        foreach (SectionKeyPair skp in keyPairs.Keys)
        {
            if (skp.Section.Equals(section))
            {
                string? keyValue = GetValue(section, skp.SectionKey);
                keysAndValues.Add(skp.SectionKey, keyValue);
            }
        }

        return keysAndValues;
    }

    /// <summary>
    /// Remove a key for given section. Returns true, if existing key was deleted.
    /// </summary>
    public bool DeleteKey(string section, string sectionKey)
    {
        bool keyIsDeleted = false;
        SectionKeyPair skp = new SectionKeyPair(section, sectionKey);

        if (keyPairs.Remove(skp))
        {
            ChangesPending = true;
            keyIsDeleted = true;
        }

        CheckAutoSaveRequired();

        return keyIsDeleted;
    }

    /// <summary>
    /// Commit/save settings to ini file.
    /// </summary>
    public void SaveIni()
    {
        List<string> sections = [];

        foreach (SectionKeyPair sectionKeyPair in keyPairs.Keys)
        {
            if (!sections.Contains(sectionKeyPair.Section))
            {
                sections.Add(sectionKeyPair.Section);
            }
        }

        StringBuilder sb = new StringBuilder();

        foreach (string section in sections)
        {
            sb.AppendLine($"[{section}]");

            foreach (SectionKeyPair sectionKeyPair in keyPairs.Keys)
            {
                if (sectionKeyPair.Section.Equals(section))
                {
                    sb.AppendLine($"{sectionKeyPair.SectionKey}={keyPairs[sectionKeyPair]}");
                }
            }
        }

        File.WriteAllText(IniFilePath, sb.ToString(), new UTF8Encoding(false));
        ChangesPending = false;
    }

    /// <summary>
    /// Reloads the ini file.
    /// </summary>
    public void ReloadIni()
    {
        ChangesPending = false;
        EnumerateSectionKeyPairs();
    }

    /// <summary>
    /// Enables ini file automatic commit/save functionality and initiates ini commit/save, if there are pending changes.
    /// </summary>
    public void EnableIniAutoSave()
    {
        IniAutoSaveEnabled = true;
        CheckAutoSaveRequired();
    }

    /// <summary>
    /// Disables ini file automatic commit/save functionality.
    /// </summary>
    public void DisableIniAutoSave()
    {
        IniAutoSaveEnabled = false;
    }

    /// <summary>
    /// Reads the ini file and enumerates its values.
    /// </summary>
    /// <exception cref="IniFileEmptyException">Thrown when the ini file is empty.</exception>
    /// <exception cref="IniEnumerationFailedException">Thrown when the ini key/value pair enumeration failed.</exception>
    private void EnumerateSectionKeyPairs()
    {
        keyPairs.Clear();

        string[] iniFile = File.ReadAllLines(IniFilePath, Encoding.UTF8);

        if (iniFile.Length == 0)
        {
            throw new IniFileEmptyException($"'{IniFilePath}' file is empty");
        }

        string currentSection = string.Empty;

        foreach (string line in iniFile)
        {
            string currentLine = line;

            // check for ';' or '#' chars, and ignore the rest of the string (comments)
            int pos = currentLine.IndexOfAny([';', '#']);

            if (pos >= 0)
            {
                string[] split = currentLine.Split(currentLine[pos]);
                currentLine = split[0];
            }

            currentLine = currentLine.Trim();

            if (currentLine != string.Empty)
            {
                if (currentLine.StartsWith("[") && currentLine.EndsWith("]"))
                {
                    currentSection = currentLine[1..^1];
                }
                else
                {
                    string[] keyPair = currentLine.Split(['='], 2);

                    if (keyPair.Length != 2)
                    {
                        throw new IniEnumerationFailedException("Ini key/value pair enumeration failed");
                    }

                    SectionKeyPair skp = new SectionKeyPair(currentSection, keyPair[0].Trim());
                    keyPairs.Add(skp, keyPair[1].Trim());
                }
            }
        }
    }

    /// <summary>
    /// Method, that checks whether SaveIni method needs to be called.
    /// </summary>
    private void CheckAutoSaveRequired()
    {
        if (IniAutoSaveEnabled && ChangesPending)
        {
            SaveIni();
        }
    }

    /// <summary>
    /// SectionKeyPair struct.
    /// </summary>
    private readonly struct SectionKeyPair
    {
        public readonly string Section;
        public readonly string SectionKey;

        public SectionKeyPair(string section, string sectionKey)
        {
            Section = section;
            SectionKey = sectionKey;
        }
    }
}
