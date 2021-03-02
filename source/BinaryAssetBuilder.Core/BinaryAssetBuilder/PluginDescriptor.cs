﻿using BinaryAssetBuilder.Core;
using BinaryAssetBuilder.Core.Xml;
using System;
using System.Collections.Generic;
using System.Xml;

namespace BinaryAssetBuilder
{
    public class PluginDescriptor : ISerializable
    {
        private IAssetBuilderPluginBase _plugin;
        private readonly List<uint> _handledTypes = new List<uint>();
        private string _assetTypes;
        private bool _isEnabled;
        private string _targetType;
        private bool _useBuildCache;

        public IAssetBuilderPluginBase Plugin => _plugin;
        public List<uint> HandledTypes => _handledTypes;
        public string AssetTypes { get => _assetTypes; set => _assetTypes = value; }
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }
        public string QualifiedName { get => _targetType; set => _targetType = value; }
        public bool UseBuildCache { get => _useBuildCache; set => _useBuildCache = value; }

        public void Initialize(TargetPlatform platform)
        {
            if (!_isEnabled)
            {
                return;
            }
            _plugin = Activator.CreateInstance(Type.GetType(_targetType) ?? throw new ApplicationException($"'{_targetType}' not found")) as IAssetBuilderPluginBase;
            if (_plugin is null)
            {
                throw new ApplicationException($"'{_targetType}' does not implement {nameof(IAssetBuilderPluginBase)}");
            }
            if (!string.IsNullOrEmpty(_assetTypes) && !_assetTypes.Equals("#all"))
            {
                foreach (string assetType in _assetTypes.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    _handledTypes.Add(InstanceHandle.GetTypeId(assetType.Trim()));
                }
            }
            _plugin.Initialize(platform);
        }

        public void ReInitialize(TargetPlatform platform)
        {
            if (!_isEnabled)
            {
                return;
            }
            if (_plugin is null)
            {
                Initialize(platform);
            }
            else
            {
                _plugin.ReInitialize(platform);
            }
        }

        public void ReadXml(Node node)
        {
            Marshaler.Marshal(node.GetAttributeValue(nameof(AssetTypes), null), ref _assetTypes);
            Marshaler.Marshal(node.GetAttributeValue(nameof(IsEnabled), null), ref _isEnabled);
            Marshaler.Marshal(node.GetAttributeValue(nameof(QualifiedName), null), ref _targetType);
            Marshaler.Marshal(node.GetAttributeValue(nameof(UseBuildCache), null), ref _useBuildCache);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(AssetTypes), _assetTypes);
            writer.WriteAttributeString(nameof(IsEnabled), _isEnabled.ToString());
            writer.WriteAttributeString(nameof(QualifiedName), _targetType);
            writer.WriteAttributeString(nameof(UseBuildCache), _useBuildCache.ToString());
        }
    }
}
