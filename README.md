# 💎 Gem Cascade

A small match-3 puzzle game about gems: swap neighbouring gems, line up 3 or more and trigger cascades.

> 🚧 **Work in progress.** Built step by step as a learning and portfolio project.

## About

| | |
|---|---|
| **Genre** | Match-3 puzzle |
| **Platform** | PC (Windows), WebGL on itch.io (planned) |
| **Controls** | Mouse |
| **Inspired by** | Bejeweled, Candy Crush Saga, Gems of War |
| **Engine** | Unity 6000.0.77f1, URP 2D |

## Features

### v0.1 MVP
- [ ] 8×8 board filled with 5 gem types, no matches at start
- [ ] Swap two neighbouring gems; the swap is reverted if it makes no match
- [ ] Match 3+ gems in a row or column to clear them
- [ ] Gems fall down, new gems fill the board, cascades give bonus points
- [ ] Auto-shuffle when no moves are left
- [ ] **Classic mode:** reach the target score within limited moves
- [ ] Main menu, mode select, HUD, win / lose screens
- [ ] Best score saved between sessions

### Planned
- Special gems (rocket, bomb, prism)
- Time Attack and Collect modes
- Levels, hints, particles and sound

## Tech

- **Unity** 6000.0.77f1, Universal Render Pipeline (2D)
- **C#**
- **Git LFS** for binary assets

## How to run

1. Install [Git LFS](https://git-lfs.com/) and run `git lfs install` once.
2. Clone the repository:
   ```bash
   git clone https://github.com/blsssdxq/Pet-Project-match-3.git
   ```
3. Open the project in **Unity 6000.0.77f1** via Unity Hub.
4. Open the scene `Assets/_Project/Scenes/Game.unity` and press **Play**.

## Project structure

```
Assets/
└── _Project/        # all game content
    ├── Scenes/
    └── Scripts/
```

## License

Code is licensed under the [MIT License](LICENSE).
