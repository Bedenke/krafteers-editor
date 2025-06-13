# Krafteers Map System Documentation

## Overview

The Krafteers map system is a sophisticated terrain generation and management system that handles both the visual representation and gameplay mechanics of the game's maps. The system consists of several key components:

1. Map Compiler
2. Map XML Format
3. Terrain Generation
4. Map Assets

## Map Compiler

The `MapCompiler` class is responsible for converting bitmap images into playable game terrain. It works by:

1. Reading bitmap files (BMP format)
2. Converting pixel colors to terrain types using DNA mapping
3. Generating terrain vertices for pathfinding
4. Saving the compiled terrain data

### Color to DNA Mapping

The compiler uses a color-to-DNA mapping system where:
- Each terrain type has an associated RGB color
- The compiler reads these colors from the bitmap
- Colors are converted to hex format for matching
- Invalid colors fall back to the last valid terrain type

### Terrain Generation Process

1. **Bitmap Reading**
   - Reads the source bitmap file
   - Extracts dimensions and pixel data

2. **Terrain Data Creation**
   - Creates a byte array for terrain data
   - Maps each pixel to a terrain type
   - Handles invalid terrain colors gracefully

3. **Vertex Generation**
   - Finds walkable vertices for pathfinding
   - Optimizes vertex placement
   - Removes redundant vertices

## Map XML Format

Maps are defined using XML files that specify:

### Basic Map Properties
```xml
<map>
    <mode>Story</mode>
    <startTime>330</startTime>
    <levels start="1" end="30" />
    <enemyLevel start="1" end="30" />
    <difficulty start="0.1" end="1" />
    <minions start="10" end="20" />
</map>
```

### Map Elements
- **Starting Position**: Defines player spawn points
- **Entities**: Places game objects using DNA references
- **Logbook**: Contains quest and progression information

### Entity Placement
```xml
<add dna="EntityName" x="X" y="Y" health="0" />
```

### Quest System
The logbook system defines progression through:
- Tasks and objectives
- Required items and actions
- Level requirements
- Highlighted areas and objects

## Map Assets

### File Structure
- `/maps/`: Contains map design files
  - `.afdesign`: Map design files
  - `bmps/`: Compiled bitmap files
  - XML configuration files

### Map Types
1. **Story Maps**
   - MainIsland
   - BattleIsland
   - Survival
   - Village

2. **Special Maps**
   - Sandbox
   - Winter
   - Dunes
   - Coast
   - Castaway

## Best Practices

1. **Map Design**
   - Use the provided color palette for terrain types
   - Ensure walkable paths are properly connected
   - Test map boundaries and collision detection

2. **Performance**
   - Optimize vertex generation for large maps
   - Use appropriate terrain density values
   - Consider pathfinding complexity

3. **Gameplay**
   - Balance resource placement
   - Design logical progression paths
   - Include appropriate challenge scaling

## Tools and Utilities

### Map Compiler Usage
```bash
# Compile a map
java -jar editor.jar maps

# Convert TIFF files to BMP
java -jar editor.jar maps tiffs
```

### Hot Reload Support
The map system supports hot reloading for:
- Map XML changes
- Terrain modifications
- Entity placement updates

## Troubleshooting

Common issues and solutions:

1. **Invalid Terrain Colors**
   - Check color values in the bitmap
   - Verify DNA color mappings
   - Use the fallback system for unknown colors

2. **Pathfinding Issues**
   - Verify vertex generation
   - Check terrain density values
   - Ensure walkable paths are connected

3. **Performance Problems**
   - Optimize vertex count
   - Reduce terrain complexity
   - Check entity density 