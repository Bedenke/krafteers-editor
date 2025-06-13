# DNA XML System Documentation

The DNA system uses XML files to define game entities in Krafteers. Each DNA file represents a unique entity type with its own properties, behaviors, and interactions.

## File Naming Convention

DNA files must follow this naming pattern:
```
<ID>.<Name>.xml
```

For example:
- `1100.TShirt.xml`
- `79.HumanBones.xml`
- `524.Gas.xml`

The ID is a permanent identifier that must be unique across all DNA files. The name is a descriptive identifier for the entity.

## Basic Structure

All DNA files follow this basic structure:
```xml
<dna>
    <!-- Properties and behaviors go here -->
</dna>
```

## Common Properties

### Basic Attributes
- `<maxHealth>` (float) - Maximum health points
- `<maxStamina>` (float) - Maximum stamina points
- `<speed>` (byte) - Movement speed
- `<expire>` (byte) - Time before entity expires (in minutes)
- `<stack>` (short) - Maximum stack size for items
- `<price>` (int) - Cost in game currency
- `<level>` (byte) - Required player level to access
- `<skus>` (string) - Premium item identifier ("none" by default)
- `<visibility>` (byte) - Visibility level (0-100)
- `<starve>` (boolean) - Whether entity loses stamina over time
- `<wander>` (boolean) - Whether entity wanders randomly

### Flags
- `<selectable>` (boolean) - Whether entity can be selected
  - Attributes:
    - `longPress` (boolean) - Whether long press is required
- `<collectible>` (boolean) - Whether entity can be collected
- `<teamRequired>` (boolean) - Whether team is required
- `<snap>` (boolean) - Whether entity snaps to grid
- `<savable>` (boolean) - Whether entity state is saved
- `<carryLinked>` (boolean) - Whether entity is linked when carried
- `<finalWave>` (boolean) - Whether entity is part of final wave
- `<sacredArea>` (boolean) - Whether entity is in sacred area
- `<deprecated>` (boolean) - Whether entity is deprecated

### Visual Properties
- `<sprite>` (string) - Visual representation
  - Attributes:
    - `scale` (float) - Size multiplier (e.g., `scale="0.7"`)
    - `frameRate` (float) - Animation frame rate
    - `offsetX` (float) - X-axis offset
    - `offsetY` (float) - Y-axis offset
    - `offsetZ` (float) - Z-axis offset
    - `layer` (string) - Layer type (e.g., "ground")
    - `drawAsEquip` (boolean) - Whether to draw as equipment
    - `skinned` (boolean) - Whether sprite is skinned
    - `shadow` (boolean) - Whether to show shadow
    - `tint` (string) - Tint color in hex format
- `<fx>` (string[]) - Space-separated list of visual effects
- `<terrainColor>` (string) - Color in hex format (e.g., `#162c4eff`)
- `<icon>` (string) - UI icon identifier

### Environmental Properties
- `<temperature>` (float) - Temperature value
- `<humidity>` (float) - Humidity value
- `<surface>` (string) - Surface type (e.g., "Land", "Sea", "Sand")
- `<mobility>` (string) - Allowed surface types
- `<terrainLevel>` (byte) - Height level in terrain
- `<height>` (float) - Entity height
- `<bounds>` (byte) - Collision bounds
- `<density>` (byte) - Population density (0-100)
- `<populationRatio>` (float) - Max entities per 100 square units
- `<fly>` (short) - Flight range

### Behavior Properties
- `<actions>` (string) - Space-separated list of available actions
- `<group>` (string) - Space-separated list of entity groups
- `<modifyStamina>` (short) - Stamina modification
- `<modifyHealth>` (short) - Health modification
- `<modifyInfection>` (short) - Infection modification
- `<modifyTemperature>` (short) - Temperature modification
- `<modifyRange>` (short) - Effect range
- `<modifyBack>` (boolean) - Whether to modify back
- `<modifyExplode>` (boolean) - Whether entity can explode
- `<modifyCounter>` (byte) - Modification counter
- `<rate>` (float) - Action rate multiplier

### Resistance & Healing
- `<resistDamage>` (float) - Damage resistance (0-1)
- `<resistHeat>` (float) - Heat resistance (0-1)
- `<resistCold>` (float) - Cold resistance (0-1)
- `<resistInfection>` (float) - Infection resistance (0-1)
- `<healHealth>` (float) - Health healing rate
- `<healStamina>` (float) - Stamina healing rate
- `<healInfection>` (float) - Infection healing rate

### Generation & Spawning
- `<generate>` (string) - Space-separated list of entities that can spawn
  - Attributes:
    - `interval` (short) - Time between generations
- `<spawn>` (Spawn[]) - Spawn configuration
  - Attributes:
    - `interval` (short) - Time between spawns
    - `range` (short) - Spawn range
- `<terrainSpawn>` (Spawn) - Terrain-specific spawn configuration
  - Attributes:
    - `interval` (short) - Time between spawns
    - `range` (short) - Spawn range
- `<split>` (string) - Space-separated list of items produced when split
  - Attributes:
    - `range` (float) - Split range
    - `dropItemsChance` (byte) - Chance to drop items (0-100)

### Item Management
- `<container>` (Container) - Container configuration
  - Attributes:
    - `dnas` (string) - Space-separated list of allowed DNA types
    - `size` (byte) - Container size
    - `stash` (boolean) - Whether container is a stash
- `<cast>` (Cast) - Item throwing configuration
  - Attributes:
    - `spawn` (boolean) - Whether to spawn on cast
    - `speed` (float) - Cast speed
    - `range` (float) - Cast range
- `<drop>` (DropItem[]) - Items dropped on death
  - Attributes:
    - `chance` (float) - Drop chance (0-100)
    - `always` (boolean) - Whether to always drop
    - `range` (float) - Drop range
- `<equip>` (string) - Equipment slot type
- `<extract>` (Extract) - Resource extraction configuration
  - Attributes:
    - `from` (string) - Source DNA type
    - `chance` (byte) - Extraction chance (0-100)

### Special Abilities
- `<morph>` (Morph) - Transformation configuration
  - Attributes:
    - `delay` (short) - Transformation delay
    - `always` (boolean) - Whether to always transform
- `<deploy>` (Deploy) - Entity deployment configuration
  - Attributes:
    - `minLevel` (byte) - Minimum level
    - `maxLevel` (byte) - Maximum level
    - `interval` (byte) - Deployment interval
    - `multiplier` (float) - Deployment multiplier
    - `triggers` (string) - Space-separated list of trigger DNA types
- `<light>` (Light) - Lighting configuration
  - Attributes:
    - `range` (float) - Light range
    - `r` (float) - Red component (0-1)
    - `g` (float) - Green component (0-1)
    - `b` (float) - Blue component (0-1)
- `<sensor>` (Sensor) - Environmental sensing configuration
  - Attributes:
    - `range` (float) - Sensor range
    - `chance` (float) - Detection chance (0-100)
    - `interval` (short) - Sensing interval
    - `spawn` (string) - DNA type to spawn
    - `activePeriod` (string) - Active time period ("start end")
    - `include` (string) - Space-separated list of included groups
    - `exclude` (string) - Space-separated list of excluded groups
    - `includeDnas` (string) - Space-separated list of included DNA types
    - `excludeDnas` (string) - Space-separated list of excluded DNA types
- `<activeHours>` (ActiveHours) - Active time period configuration
  - Attributes:
    - `start` (byte) - Start hour (0-23)
    - `end` (byte) - End hour (0-23)

### Intelligence & Behavior
- `<targeting>` (string) - Targeting behavior
- `<pathfindMode>` (string) - Pathfinding mode
- `<pathfindRange>` (short) - Pathfinding range
- `<chase>` (GroupBehavior) - Entities to pursue
  - Attributes:
    - `exclude` (string) - Space-separated list of excluded groups
    - `includeDnas` (string) - Space-separated list of included DNA types
    - `excludeDnas` (string) - Space-separated list of excluded DNA types
- `<evade>` (GroupBehavior) - Entities to avoid
- `<follow>` (GroupBehavior) - Entities to follow
- `<consume>` (GroupBehavior) - Entities to consume

### Game State
- `<gameState>` (string) - Current game state
- `<requiredGameState>` (string) - Required game state
- `<countdown>` (int) - Time-based behavior counter
- `<counterMode>` (string) - Counter behavior mode
- `<forwardTime>` (short) - Time advancement in minutes

### Recipes
- `<recipe>` (Recipe[]) - Recipe configurations
  - Attributes:
    - `price` (float) - Recipe cost
- `<recipePriority>` (short) - Recipe priority
- `<createWith>` (string) - Space-separated list of items created with

### Editor
- `<editor>` (Editor) - Editor configuration
  - Attributes:
    - `category` (string) - Editor category

## Inheritance

DNA files can extend other DNA files using the `extends` attribute:
```xml
<dna extends="./1006.PlayerFemale.xml">
    <sprite scale="1" offsetZ="0">Player3</sprite>
    <price>100</price>
    <maxStamina>500</maxStamina>
    <speed>5</speed>
    <recipePriority>4</recipePriority>
</dna>
```

## Best Practices

1. **Naming**: Use clear, descriptive names for entities
2. **Organization**: Keep DNA files organized in appropriate directories (terrain, animals, tools, etc.)
3. **Balance**: Consider the impact of properties on game balance
4. **Performance**: Be mindful of population ratios and density settings
5. **Inheritance**: Use extends to avoid duplicating common properties
6. **IDs**: Never reuse IDs across different entities
7. **Types**: Use appropriate data types for each property
8. **Validation**: Ensure all required attributes are present
9. **References**: Verify that referenced DNA types exist
10. **Ranges**: Keep numeric values within their valid ranges 