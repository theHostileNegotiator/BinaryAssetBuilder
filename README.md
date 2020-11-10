# BinaryAssetBuilder
BinaryAssetBuilder implementation for Kane's Wrath in .Net Core

### First Version will be for Tiberium Wars
I decided to first make a TW version so I can be sure everything works.

### Implemented Asset Types
* [ ] TestGameObject
* [ ] TestTexture
* [ ] TestTextureCollection
* [x] WeaponTemplate                                            0xE3996069
* [x] LocomotorTemplate                                         0xBD8F61A4
* [ ] GameObject
* [ ] FXParticleSystemTemplate
* [x] Weather                                                   0x368A8BA2
* [x] ShadowMap                                                 0xC6389FA6
* [x] WaterTransparency                                         0x331DA6CE
* [ ] Texture
* [ ] OnDemandTexture
* [ ] W3DMesh
* [ ] W3DContainer
* [ ] W3DHierarchy
* [x] W3DAnimation                                              0xCC069193
* [ ] W3DCollisionBox
* [ ] ArmyDefinition
* [ ] AIPersonalityDefinition
* [ ] FXList
* [ ] ObjectCreationList
* [ ] ObjectFilterAsset
* [ ] SpecialPowerTemplate
* [ ] UpgradeTemplate
* [ ] SkirmishOpeningMove
* [ ] AIStateDefinition
* [ ] AIStrategicStateDefinition
* [ ] AIBudgetStateDefinition
* [ ] AITargetingHeuristic
* [ ] GameMap
* [ ] AttributeModifier
* [ ] ArmorTemplate
* [ ] MissionTemplate
* [ ] TheaterOfWarTemplate
* [ ] CampaignTemplate
* [ ] RadiusCursorLibrary
* [ ] AudioFile
* [ ] AudioEvent
* [ ] MusicTrack
* [ ] DialogEvent
* [ ] AmbientStream
* [ ] Multisound
* [ ] MusicPalette
* [ ] MusicScriptConditionNugget_LocalPlayerIsObserver
* [ ] MusicScriptConditionNugget_UnitsFarFromBase
* [ ] MusicScriptConditionNugget_TimeFromStartOfLevel
* [ ] MusicScriptConditionNugget_TrackPlayedCount
* [ ] MusicScriptConditionNugget_SpecificTrackTypePlaying
* [ ] MusicScriptConditionNugget_AnyTrackPlaying
* [ ] MusicScriptConditionNugget_ObjectsOfTypeExist
* [ ] MusicScriptConditionNugget_EvaEventPlayedRecently
* [ ] MusicScriptConditionNugget_ObjectsNearEvaEvent
* [ ] MusicScriptConditionNugget_ScoredKillCount
* [ ] MusicScriptConditionNugget_Not
* [ ] MusicScriptConditionNugget_Or
* [ ] MusicScriptConditionNugget_And
* [ ] MusicScriptTrack
* [ ] LocalBuildListMonitor
* [x] MpGameRules                                               0xEDDBB607
* [ ] ExperienceLevelTemplate
* [ ] MissionObjectiveList
* [x] StringHashTable                                           0x2C112832
* [ ] InGameUISettings
* [ ] DamageFX
* [ ] MultiplayerSettings
* [ ] OnlineChatColors
* [ ] MultiplayerColor
* [ ] GameLODPreset
* [ ] StaticGameLOD
* [ ] DynamicGameLOD
* [ ] AudioLOD
* [ ] VideoEventList
* [ ] UIConfigList
* [x] PackedTextureImage                                        0x2FAEB748
* [ ] OnDemandTextureImage
* [ ] TerrainTextureAtlas
* [x] Mouse                                                     0x73FE99B0
* [x] Achievement                                               0xC8D16E6D
* [x] StanceTemplate                                            0x5C6E0E41
* [x] TargetingCompareList                                      0x57CA5C81
* [x] TargetingDistanceCompare                                  0xED45F096
* [x] TargetingCombatChainCompare                               0x553808EF
* [x] TargetingInTurretArcCompare                               0xCD24391A
* [x] Road                                                      0xDCF3C28B
* [x] Environment                                               0x878C42E0
* [x] LogicCommand                                              0x97D0A46E
* [x] LogicCommandSet                                           0x6D148BD7
* [x] MiscAudio                                                 0xFA4817E2
* [x] AudioSettings                                             0x89AA7DDE
* [x] CrowdResponse                                             0x66FB33A0
* [x] MapMetaData                                               0x59013A51
* [x] LargeGroupAudioMap                                        0x9CBC0553
* [x] AptAptData                                                0x36866072
* [x] AptConstData                                              0x1CE8E595
* [x] AptDatData                                                0x3BF7FEB9
* [x] AptGeometryData                                           0x58F89E8B
* [x] MappableKey                                               0xE005A668
* [x] HotKeySlot                                                0x1AC54E60
* [x] DefaultHotKeys                                            0x0E12479D
* [x] InGameUIGroupSelectionCommandSlots                        0xF6CE1A68
* [x] InGameUILookAtCommandSlots                                0x8F9F9918
* [x] InGameUITacticalCommandSlots                              0xC24AEFF1
* [x] InGameUIVoiceChatCommandSlots                             0x3592E352
* [x] InGameUISideBarCommandSlots                               0xAF956455
* [x] InGameUIPlayerPowerCommandSlots                           0x4AB425C6
* [x] InGameUIUnitAbilityCommandSlots                           0x9DAA4182
* [x] GameScriptList                                            0x5AC6FA18
* [x] IntelDB                                                   0xFBB64F90
* [x] BootupDisplaySequence                                     0x84C1C2F0
* [x] UnitTypeIcon                                              0xF7AB74BE
* [x] ImageSequence                                             0x217CF953
* [x] UnitOverlayIconSettings                                   0xDFC78E66
* [x] TheVersion                                                0xF659EF49
* [x] DLContent                                                 0x4E1A5713
* [x] PhaseEffect                                               0x4877D566
* [x] ConnectionLineManager                                     0x7AEB73B2
* [x] InGameUIFixedElementHotKeySlotMap                         0x475EA260

### Tiberium Wars Only Types
* [ ] AudioFileMP3Passthrough
* [ ] MP3MusicTrack
* [ ] MP3DialogEvent
* [ ] MP3AmbientStream
* [ ] UnitAbilityButtonTemplateStore
* [ ] PlayerPowerButtonTemplateStore
* [x] CommandSet                                                0x3CFF78A1

### Kane's Wrath Only Types
* [ ] UnitAbilityButtonTemplate
* [ ] PlayerPowerButtonTemplate
* [ ] StrikeForceBuildTemplate
* [ ] MetagameOperationsInfoType
* [ ] MetaGameUITacticalCommandSlots
* [ ] MetaGameUICommonOpCommandSlots
* [ ] MetaGameMapZoneData
* [ ] MetaGameStaticData
* [ ] ButtonSingleStateData
* [ ] JoypadCommandBarTemplate
* [ ] JoypadCommandBarButtonTemplate
* [ ] UIJoypadCommandBarButtonBuild
* [ ] UIJoypadCommandBarHomogenousGroup
* [ ] UIJoypadCommandBarMixedGroup
* [ ] UIJoypadCommandBarSingleUnit
* [ ] UIJoypadCommandBarStances
* [ ] UIJoypadCommandBarTopMenu
* [ ] UIJoypadCommandBarMgTopMenu
