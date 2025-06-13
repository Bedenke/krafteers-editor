# Krafteers Editor Documentation

## Compiler Arguments

The Krafteers compiler supports several command-line arguments to control what gets compiled:

- `launch`: Launches the editor after compilation
- `textures`: Compiles sprite textures
- `maps`: Compiles BMP maps and DNAs
- `dnas`: Compiles DNA files
- `sounds`: Compiles sound files

### Usage Examples

```bash
# Just launch the editor
java -jar editor.jar launch

# Compile everything and launch editor
java -jar editor.jar launch textures maps dnas sounds

# Only compile textures into altas
java -jar editor.jar textures

```

## Textures and name conventions

The Krafteers texture system uses a texture atlas to efficiently manage game sprites. All sprites are packed into a single texture atlas (`DefaultSprites.atlas`) for better performance.

### Character Sprite Naming Conventions

Character sprites follow these naming patterns:
- Base sprites: `[CharacterName].png` (e.g., `Demon.png`, `Shaman.png`)
- Directional sprites: `[CharacterName]_[Direction]_[Frame].png`
  - Directions: `N` (North), `S` (South)
  - Frames: `0` through `3`
  - Example: `Demon_N_0.png`, `Demon_S_3.png`
- Resting sprites: `[CharacterName]_R.png` (e.g., `Shaman_R.png`)
- Icons: `[CharacterName]Icon.png` (e.g., `DemonIcon.png`)

### Item Sprite Naming Conventions

Item sprites follow these patterns:
- Base items: `[ItemName].png` (e.g., `Stone.png`, `Water.png`)
- Craft icons: `[ItemName]CraftIcon.png` (e.g., `StoneCraftIcon.png`)
- Animated items: `[ItemName]_[Frame].png` (e.g., `ActivePortal_0.png`, `ActivePortal_1.png`)

### Texture System Architecture

The texture system consists of three main components:

1. **TextureAssets**
   - Main entry point for texture management
   - Loads the texture atlas from `data/sprites/DefaultSprites.atlas`
   - Manages texture disposal and lifecycle

2. **Sprite**
   - Represents a single sprite in the atlas
   - Stores UV coordinates, scaling, and offset information
   - Uses `TextureRegionDrawable` for rendering
   - Can be created from either a `TextureRegion` or `AtlasRegion`

3. **PoseSprites**
   - Handles character animations
   - Manages different sprite sets:
     - `main`: Base character sprite
     - `rest`: Resting animation frames
     - `north`: North-facing animation frames
     - `south`: South-facing animation frames
   - Provides methods to get appropriate sprites based on:
     - Angle (N/S/W/E)
     - Frame number
     - Resting state

### Hot Reloading

The texture system supports hot reloading during development:
- Monitors the `../dnas/sprites/` directory for changes
- Automatically repacks the texture atlas when sprite files change
- Supports PNG, JPG, and JSON files
- Updates the game context and DNA maps when textures change

The hot reload system provides real-time updates during development by monitoring and automatically reloading various game assets when they change.

### Monitored Assets

The system watches for changes in:

1. **Game Configuration** (`game.xml`)
2. **DNA Files** (`dna.dat`)
3. **Translation Files** (`translation.*.properties`)
4. **Texture Assets** (`DefaultSprites.png`)

### How It Works

1. **Monitoring Thread**
   - Runs in the background checking for file modifications every second
   - Monitors both source files and compiled assets

2. **DNA Compilation**
   - Watches the `../dnas/dna/` directory for XML changes
   - Automatically recompiles DNA files when source files change
   - Outputs to `./data/config/dna.dat`

3. **Texture Packing**
   - Monitors the `../dnas/sprites/` directory
   - Triggers texture repacking when sprite files change
   - Supports PNG, JPG, and JSON files

4. **Asset Reloading**
   When changes are detected, the system:
   - Reloads textures and updates texture atlases
   - Refreshes game context and DNA maps
   - Updates translations

The `HotReloadChanges` class tracks which assets were modified:
- `gameXml`: Game configuration changes
- `dnas`: DNA file changes
- `translation`: Translation file changes
- `texture`: Texture/sprite changes

### Best Practices

1. Keep the editor running while making changes to assets
2. Changes to DNA files will automatically trigger recompilation
3. Sprite changes will automatically trigger texture repacking
4. The system handles dependencies (e.g., texture changes will trigger DNA reloads)
5. Use the listener interface to handle specific asset reloading in your game code 