# Vietcong HD Remaster Launcher

This is the launcher for the [Vietcong HD Remaster](https://www.moddb.com/mods/del-vietcong-hd-remaster) project.

## Getting Started

- Download the latest release from [here](https://github.com/lofcz/VietcongRemasteredLauncher/releases).
- Unzip the downloaded file and place `hd_remaster_launcher.exe` into the folder with the game (make sure `vietcong.exe` is in the same folder). 
- Start the launcher and enjoy the game!

![screen](https://github.com/user-attachments/assets/65ef853a-b3b3-44ec-82a2-39fe5d8f608b)

## Localization

The launcher is currently localized into `en-en`, `de-de`, `pl-pl`, and `cs-cz` locales. After the first launch, `vrc.json` is created in the working directory. From this file culture can be forced:
```json
{
    "culture": "en-en"
}
```

The system culture is used by default, with `en-en` fallback.

## Building

Vietcong HD Remaster currently targets `.net framework 4.7.2` to produce small binaries. After cloning and restoring the repository, building should work in any standard IDE (JetBrains, Visual Studio). The build creates a single executable with all resources embedded.
