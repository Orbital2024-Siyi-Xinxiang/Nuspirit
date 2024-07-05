#include "pch-cpp.hpp"





template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};

struct AdaptivePerformanceSubsystemBase_3_t68140149CB11930DF74CA40FD816D7A79C3B6637;
struct AdaptivePerformanceSubsystemBase_3_tC5B76CDEB4C187C57E29DE16FA78DD53C40A1987;
struct SubsystemWithProvider_3_tB43E7390AB260ADBC542CF6E0E76631CE8CBA8D0;
struct SubsystemWithProvider_3_t548D9C2A4778C7ADB62496A2A07F8B7563309893;
struct AdaptivePerformanceScalerProfileU5BU5D_t502F55D3686CAB852984FDB6F92431963616F4B7;
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
struct AdaptivePerformanceIndexer_tE43B4A07AF7944322BA939E2D4F8AE90AD42EF73;
struct AdaptivePerformanceIndexerSettings_t3D9418B7302C8FCA3344719FF10FBADFD2F1CDC6;
struct AdaptivePerformanceScaler_tB9F76E7E942E332BEF5DC363BE906AD4FD1700BC;
struct AdaptivePerformanceScalerSettings_tAF8002CE95F36DE71E945DA73AADB6783EB2FFD8;
struct AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA;
struct AdaptivePerformanceSubsystem_t2D41A24C328589A3018DA0478476D2591E9B5C23;
struct AdaptivePerformanceSubsystemDescriptor_t5D0468D8D509E8995FBDCD5DE6EF6F293B16DC82;
struct AdaptiveViewDistance_tC58AE1BFB8F375552BE5FE700AE912039CD69BF7;
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
struct Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184;
struct IAdaptivePerformanceSettings_tFB49C60F821F093D3F18E8DC115E7D929E6C86C8;
struct IApplicationLifecycle_tD2CAC721E42E96F6573349B22EADAF166F7A4DCC;
struct IDevicePerformanceLevelControl_t894EA40FAE48D533C71232E4AE425D2DA8C142D5;
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C;
struct String_t;
struct SubsystemProvider_tE1865B8FE698C81A59AED35E0E536BD53F402455;
struct Type_t;
struct Version_tE426DB5655D0F22920AE16A2AA9AB7781B8255A7;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
struct APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998;
struct CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD;

IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709;
IL2CPP_EXTERN_C const RuntimeMethod* AdaptivePerformanceSubsystemBase_3__ctor_mC0ACA968EAB84D845C73965E57A907FC1F7351C7_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct AdaptivePerformanceScalerSettings_tAF8002CE95F36DE71E945DA73AADB6783EB2FFD8  : public RuntimeObject
{
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveFramerate;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveResolution;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveBatching;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveLOD;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveLut;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveMSAA;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveShadowCascade;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveShadowDistance;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveShadowmapResolution;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveShadowQuality;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveSorting;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveTransparency;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveViewDistance;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptivePhysics;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveDecals;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_AdaptiveLayerCulling;
};
struct AdaptivePerformanceSubsystemRegistry_tE2DCF9BCDDA4AB834A9BA4203B827C8E320AEA96  : public RuntimeObject
{
};
struct MemberInfo_t  : public RuntimeObject
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct SubsystemDescriptorWithProvider_t2A61A2C951A4A179E898CF207726BF6B5AF474D5  : public RuntimeObject
{
	String_t* ___U3CidU3Ek__BackingField;
};
struct SubsystemProvider_tE1865B8FE698C81A59AED35E0E536BD53F402455  : public RuntimeObject
{
	bool ___m_Running;
};
struct SubsystemWithProvider_tC72E35EE2D413A4B0635B058154BABF265F31242  : public RuntimeObject
{
	bool ___U3CrunningU3Ek__BackingField;
	SubsystemProvider_tE1865B8FE698C81A59AED35E0E536BD53F402455* ___U3CproviderBaseU3Ek__BackingField;
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct Version_tE426DB5655D0F22920AE16A2AA9AB7781B8255A7  : public RuntimeObject
{
	int32_t ____Major;
	int32_t ____Minor;
	int32_t ____Build;
	int32_t ____Revision;
};
struct SubsystemDescriptorWithProvider_2_t7A24A40A481885ED81D88CFBC8504FF67693053E  : public SubsystemDescriptorWithProvider_t2A61A2C951A4A179E898CF207726BF6B5AF474D5
{
};
struct SubsystemProvider_1_t6ABBE424F6F1310EE46EEA513835617E7669F669  : public SubsystemProvider_tE1865B8FE698C81A59AED35E0E536BD53F402455
{
};
struct SubsystemWithProvider_3_tB43E7390AB260ADBC542CF6E0E76631CE8CBA8D0  : public SubsystemWithProvider_tC72E35EE2D413A4B0635B058154BABF265F31242
{
	AdaptivePerformanceSubsystemDescriptor_t5D0468D8D509E8995FBDCD5DE6EF6F293B16DC82* ___U3CsubsystemDescriptorU3Ek__BackingField;
	APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* ___U3CproviderU3Ek__BackingField;
};
struct SubsystemWithProvider_3_t548D9C2A4778C7ADB62496A2A07F8B7563309893  : public SubsystemWithProvider_tC72E35EE2D413A4B0635B058154BABF265F31242
{
	RuntimeObject* ___U3CsubsystemDescriptorU3Ek__BackingField;
	RuntimeObject* ___U3CproviderU3Ek__BackingField;
};
struct AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D 
{
	String_t* ___Name;
	int32_t ___Level;
};
struct AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshaled_pinvoke
{
	char* ___Name;
	int32_t ___Level;
};
struct AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshaled_com
{
	Il2CppChar* ___Name;
	int32_t ___Level;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 
{
	int32_t ___U3CBigCoreU3Ek__BackingField;
	int32_t ___U3CMediumCoreU3Ek__BackingField;
	int32_t ___U3CLittleCoreU3Ek__BackingField;
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2  : public ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_pinvoke
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_com
{
};
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	float ___m_value;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB 
{
	String_t* ___U3CidU3Ek__BackingField;
	Type_t* ___U3CproviderTypeU3Ek__BackingField;
	Type_t* ___U3CsubsystemTypeOverrideU3Ek__BackingField;
	Type_t* ___U3CsubsystemImplementationTypeU3Ek__BackingField;
};
struct Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshaled_pinvoke
{
	char* ___U3CidU3Ek__BackingField;
	Type_t* ___U3CproviderTypeU3Ek__BackingField;
	Type_t* ___U3CsubsystemTypeOverrideU3Ek__BackingField;
	Type_t* ___U3CsubsystemImplementationTypeU3Ek__BackingField;
};
struct Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshaled_com
{
	Il2CppChar* ___U3CidU3Ek__BackingField;
	Type_t* ___U3CproviderTypeU3Ek__BackingField;
	Type_t* ___U3CsubsystemTypeOverrideU3Ek__BackingField;
	Type_t* ___U3CsubsystemImplementationTypeU3Ek__BackingField;
};
struct AdaptivePerformanceSubsystemBase_3_t68140149CB11930DF74CA40FD816D7A79C3B6637  : public SubsystemWithProvider_3_tB43E7390AB260ADBC542CF6E0E76631CE8CBA8D0
{
};
struct AdaptivePerformanceSubsystemDescriptor_t5D0468D8D509E8995FBDCD5DE6EF6F293B16DC82  : public SubsystemDescriptorWithProvider_2_t7A24A40A481885ED81D88CFBC8504FF67693053E
{
};
struct Feature_t9EAFA6FC987A8E73645DF83E49D1DB313EED6EEB 
{
	int32_t ___value__;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	intptr_t ___m_CachedPtr;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr;
};
struct PerformanceMode_t802427AAFDD60AC7A3A3EE23B05F30BAD2680F56 
{
	int32_t ___value__;
};
struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	intptr_t ___value;
};
struct ScalerTarget_t71099773D559A0B6FFBE96D127995F64D34AB2C2 
{
	int32_t ___value__;
};
struct ScalerVisualImpact_t20DF9E42BF98E7304D6B9440C2A8F38D4D7248BA 
{
	int32_t ___value__;
};
struct WarningLevel_t5C5B992767B63159DE16F2E667AECCB6592DB4AC 
{
	int32_t ___value__;
};
struct APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998  : public SubsystemProvider_1_t6ABBE424F6F1310EE46EEA513835617E7669F669
{
};
struct AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA  : public RuntimeObject
{
	String_t* ___m_Name;
	bool ___m_Enabled;
	float ___m_Scale;
	int32_t ___m_VisualImpact;
	int32_t ___m_Target;
	int32_t ___m_MaxLevel;
	float ___m_MinBound;
	float ___m_MaxBound;
};
struct AdaptivePerformanceSubsystem_t2D41A24C328589A3018DA0478476D2591E9B5C23  : public AdaptivePerformanceSubsystemBase_3_t68140149CB11930DF74CA40FD816D7A79C3B6637
{
};
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};
struct PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83 
{
	int32_t ___U3CChangeFlagsU3Ek__BackingField;
	float ___U3CTemperatureLevelU3Ek__BackingField;
	float ___U3CTemperatureTrendU3Ek__BackingField;
	int32_t ___U3CWarningLevelU3Ek__BackingField;
	int32_t ___U3CCpuPerformanceLevelU3Ek__BackingField;
	int32_t ___U3CGpuPerformanceLevelU3Ek__BackingField;
	bool ___U3CPerformanceLevelControlAvailableU3Ek__BackingField;
	float ___U3CCpuFrameTimeU3Ek__BackingField;
	float ___U3CGpuFrameTimeU3Ek__BackingField;
	float ___U3COverallFrameTimeU3Ek__BackingField;
	bool ___U3CCpuPerformanceBoostU3Ek__BackingField;
	bool ___U3CGpuPerformanceBoostU3Ek__BackingField;
	ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 ___U3CClusterInfoU3Ek__BackingField;
	int32_t ___U3CPerformanceModeU3Ek__BackingField;
};
struct PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshaled_pinvoke
{
	int32_t ___U3CChangeFlagsU3Ek__BackingField;
	float ___U3CTemperatureLevelU3Ek__BackingField;
	float ___U3CTemperatureTrendU3Ek__BackingField;
	int32_t ___U3CWarningLevelU3Ek__BackingField;
	int32_t ___U3CCpuPerformanceLevelU3Ek__BackingField;
	int32_t ___U3CGpuPerformanceLevelU3Ek__BackingField;
	int32_t ___U3CPerformanceLevelControlAvailableU3Ek__BackingField;
	float ___U3CCpuFrameTimeU3Ek__BackingField;
	float ___U3CGpuFrameTimeU3Ek__BackingField;
	float ___U3COverallFrameTimeU3Ek__BackingField;
	int32_t ___U3CCpuPerformanceBoostU3Ek__BackingField;
	int32_t ___U3CGpuPerformanceBoostU3Ek__BackingField;
	ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 ___U3CClusterInfoU3Ek__BackingField;
	int32_t ___U3CPerformanceModeU3Ek__BackingField;
};
struct PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshaled_com
{
	int32_t ___U3CChangeFlagsU3Ek__BackingField;
	float ___U3CTemperatureLevelU3Ek__BackingField;
	float ___U3CTemperatureTrendU3Ek__BackingField;
	int32_t ___U3CWarningLevelU3Ek__BackingField;
	int32_t ___U3CCpuPerformanceLevelU3Ek__BackingField;
	int32_t ___U3CGpuPerformanceLevelU3Ek__BackingField;
	int32_t ___U3CPerformanceLevelControlAvailableU3Ek__BackingField;
	float ___U3CCpuFrameTimeU3Ek__BackingField;
	float ___U3CGpuFrameTimeU3Ek__BackingField;
	float ___U3COverallFrameTimeU3Ek__BackingField;
	int32_t ___U3CCpuPerformanceBoostU3Ek__BackingField;
	int32_t ___U3CGpuPerformanceBoostU3Ek__BackingField;
	ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 ___U3CClusterInfoU3Ek__BackingField;
	int32_t ___U3CPerformanceModeU3Ek__BackingField;
};
struct ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};
struct ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A_marshaled_pinvoke : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
};
struct ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A_marshaled_com : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
};
struct Type_t  : public MemberInfo_t
{
	RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ____impl;
};
struct AdaptivePerformanceScaler_tB9F76E7E942E332BEF5DC363BE906AD4FD1700BC  : public ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A
{
	AdaptivePerformanceIndexer_tE43B4A07AF7944322BA939E2D4F8AE90AD42EF73* ___m_Indexer;
	int32_t ___U3CCurrentLevelU3Ek__BackingField;
	int32_t ___U3CGpuImpactU3Ek__BackingField;
	int32_t ___U3CCpuImpactU3Ek__BackingField;
	int32_t ___m_OverrideLevel;
	AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___m_defaultSetting;
	AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D ___m_ScalerEvent;
	IAdaptivePerformanceSettings_tFB49C60F821F093D3F18E8DC115E7D929E6C86C8* ___m_Settings;
};
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};
struct IAdaptivePerformanceSettings_tFB49C60F821F093D3F18E8DC115E7D929E6C86C8  : public ScriptableObject_tB3BFDB921A1B1795B38A5417D3B97A89A140436A
{
	bool ___m_Logging;
	bool ___m_AutomaticPerformanceModeEnabled;
	bool ___m_AutomaticGameModeEnabled;
	bool ___m_EnableBoostOnStartup;
	int32_t ___m_StatsLoggingFrequencyInFrames;
	AdaptivePerformanceIndexerSettings_t3D9418B7302C8FCA3344719FF10FBADFD2F1CDC6* ___m_IndexerSettings;
	AdaptivePerformanceScalerSettings_tAF8002CE95F36DE71E945DA73AADB6783EB2FFD8* ___m_ScalerSettings;
	AdaptivePerformanceScalerProfileU5BU5D_t502F55D3686CAB852984FDB6F92431963616F4B7* ___m_scalerProfileList;
	int32_t ___m_DefaultScalerProfilerIndex;
};
struct AdaptiveViewDistance_tC58AE1BFB8F375552BE5FE700AE912039CD69BF7  : public AdaptivePerformanceScaler_tB9F76E7E942E332BEF5DC363BE906AD4FD1700BC
{
	float ___m_DefaultFarClipPlane;
};
struct Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
	uint32_t ___m_NonSerializedVersion;
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_StaticFields
{
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject;
};
struct Type_t_StaticFields
{
	Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235* ___s_defaultBinder;
	Il2CppChar ___Delimiter;
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___EmptyTypes;
	RuntimeObject* ___Missing;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterAttribute;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterName;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterNameIgnoreCase;
};
struct Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184_StaticFields
{
	CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD* ___onPreCull;
	CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD* ___onPreRender;
	CameraCallback_t844E527BFE37BC0495E7F67993E43C07642DA9DD* ___onPostRender;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif


IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AdaptivePerformanceSubsystemBase_3__ctor_m74C2D799C6BB1B311039CE9CE2FED174549F683D_gshared (AdaptivePerformanceSubsystemBase_3_tC5B76CDEB4C187C57E29DE16FA78DD53C40A1987* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* SubsystemWithProvider_3_get_provider_m963D70D839CE42A2C17A2C183A61C25F0E2C6732_gshared_inline (SubsystemWithProvider_3_t548D9C2A4778C7ADB62496A2A07F8B7563309893* __this, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AdaptivePerformanceScaler_Awake_m9AFB587F718F1FB523F3F7EC1A5CE083E8AFE576 (AdaptivePerformanceScaler_tB9F76E7E942E332BEF5DC363BE906AD4FD1700BC* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___0_x, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___1_y, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AdaptivePerformanceScalerSettings_tAF8002CE95F36DE71E945DA73AADB6783EB2FFD8* IAdaptivePerformanceSettings_get_scalerSettings_mB33C0AAA3A6CA0B05E9B1E205853D1698A088575 (IAdaptivePerformanceSettings_tFB49C60F821F093D3F18E8DC115E7D929E6C86C8* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* AdaptivePerformanceScalerSettings_get_AdaptiveViewDistance_mE7E45AB3EC0919AAF5B9F80D395C676B7B4143A9 (AdaptivePerformanceScalerSettings_tAF8002CE95F36DE71E945DA73AADB6783EB2FFD8* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AdaptivePerformanceScaler_ApplyDefaultSetting_m55A6880662648019B4AABE1E644B8B3C1B1D7D19 (AdaptivePerformanceScaler_tB9F76E7E942E332BEF5DC363BE906AD4FD1700BC* __this, AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* ___0_defaultSetting, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* Camera_get_main_m52C992F18E05355ABB9EEB64A4BF2215E12762DF (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___0_exists, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Camera_set_farClipPlane_m84EF39B09573168734613481FD979BFF31C60139 (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* __this, float ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float Camera_get_farClipPlane_m1D7128B85B5DB866F75FBE8CEBA48335716B67BD (Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AdaptivePerformanceScaler_ScaleChanged_m8CA4C17F6CFFEE7ECBFF95720EB205A2DA01A6BE (AdaptivePerformanceScaler_tB9F76E7E942E332BEF5DC363BE906AD4FD1700BC* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AdaptivePerformanceScaler__ctor_m1DAA2566D0A20850A60AB246C8578D69BB93A5D5 (AdaptivePerformanceScaler_tB9F76E7E942E332BEF5DC363BE906AD4FD1700BC* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_ChangeFlags_m83DE31AF3877A2A1507A6703B190533FD166B9B7_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_TemperatureLevel_mF48F6ECD619E7DD65811410891B4AB7B9B218865_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_TemperatureTrend_mF1A3DF7A654F1A20A4D9A70647B4250E734D6467_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_WarningLevel_m0C061FD490DF445A1D1347DBC5F798B206B5DB35_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_CpuPerformanceLevel_mF688EC621C77916A86F96CF7D0DAFD520B6D68E8_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_GpuPerformanceLevel_mA928B60EF914AB4E7D95291E1357A3FE795DBE23_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool PerformanceDataRecord_get_PerformanceLevelControlAvailable_mB2379A58631D8AAE1AE389560BF46951ABE7D80F_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_CpuFrameTime_m64C3D3C8D2D7F3670DCC3EE2026B805DADF614BE_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_GpuFrameTime_mFA20351C75C59AF7861FCE6E9A859AE0FD75C767_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_OverallFrameTime_m6ABDF5F1B04E6FF9BDD96AFA00844F84E6570D90_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool PerformanceDataRecord_get_CpuPerformanceBoost_m55A78568F8E19144717C3CEC17CE90FA766591D2_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool PerformanceDataRecord_get_GpuPerformanceBoost_mFD01BBFC9A9BE53ED81947089A02691635789B7E_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 PerformanceDataRecord_get_ClusterInfo_m6EC3F093AE1024050D8C7FEAECCC7153668CB187_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_PerformanceMode_mEF911B8B3207795B86E013D3DFF2679A599D78DF_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) ;
inline void AdaptivePerformanceSubsystemBase_3__ctor_mC0ACA968EAB84D845C73965E57A907FC1F7351C7 (AdaptivePerformanceSubsystemBase_3_t68140149CB11930DF74CA40FD816D7A79C3B6637* __this, const RuntimeMethod* method)
{
	((  void (*) (AdaptivePerformanceSubsystemBase_3_t68140149CB11930DF74CA40FD816D7A79C3B6637*, const RuntimeMethod*))AdaptivePerformanceSubsystemBase_3__ctor_m74C2D799C6BB1B311039CE9CE2FED174549F683D_gshared)(__this, method);
}
inline APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_inline (SubsystemWithProvider_3_tB43E7390AB260ADBC542CF6E0E76631CE8CBA8D0* __this, const RuntimeMethod* method)
{
	return ((  APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* (*) (SubsystemWithProvider_3_tB43E7390AB260ADBC542CF6E0E76631CE8CBA8D0*, const RuntimeMethod*))SubsystemWithProvider_3_get_provider_m963D70D839CE42A2C17A2C183A61C25F0E2C6732_gshared_inline)(__this, method);
}
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AdaptiveViewDistance_Awake_m657355FF95F7D724D5C3E9B00F701941E6EB5460 (AdaptiveViewDistance_tC58AE1BFB8F375552BE5FE700AE912039CD69BF7* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		AdaptivePerformanceScaler_Awake_m9AFB587F718F1FB523F3F7EC1A5CE083E8AFE576(__this, NULL);
		IAdaptivePerformanceSettings_tFB49C60F821F093D3F18E8DC115E7D929E6C86C8* L_0 = ((AdaptivePerformanceScaler_tB9F76E7E942E332BEF5DC363BE906AD4FD1700BC*)__this)->___m_Settings;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Equality_mB6120F782D83091EF56A198FCEBCF066DB4A9605(L_0, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		V_0 = L_1;
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_001a;
		}
	}
	{
		goto IL_0031;
	}

IL_001a:
	{
		IAdaptivePerformanceSettings_tFB49C60F821F093D3F18E8DC115E7D929E6C86C8* L_3 = ((AdaptivePerformanceScaler_tB9F76E7E942E332BEF5DC363BE906AD4FD1700BC*)__this)->___m_Settings;
		NullCheck(L_3);
		AdaptivePerformanceScalerSettings_tAF8002CE95F36DE71E945DA73AADB6783EB2FFD8* L_4;
		L_4 = IAdaptivePerformanceSettings_get_scalerSettings_mB33C0AAA3A6CA0B05E9B1E205853D1698A088575(L_3, NULL);
		NullCheck(L_4);
		AdaptivePerformanceScalerSettingsBase_tDF99867134986926CE22505B0B9EE99AD74501AA* L_5;
		L_5 = AdaptivePerformanceScalerSettings_get_AdaptiveViewDistance_mE7E45AB3EC0919AAF5B9F80D395C676B7B4143A9(L_4, NULL);
		AdaptivePerformanceScaler_ApplyDefaultSetting_m55A6880662648019B4AABE1E644B8B3C1B1D7D19(__this, L_5, NULL);
	}

IL_0031:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AdaptiveViewDistance_OnDisabled_m3AA59B1A67474EA468C95AEE6D733C17BB19EE12 (AdaptiveViewDistance_tC58AE1BFB8F375552BE5FE700AE912039CD69BF7* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t G_B3_0 = 0;
	{
		Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* L_0;
		L_0 = Camera_get_main_m52C992F18E05355ABB9EEB64A4BF2215E12762DF(NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A(L_0, NULL);
		if (!L_1)
		{
			goto IL_001c;
		}
	}
	{
		float L_2 = __this->___m_DefaultFarClipPlane;
		G_B3_0 = ((((float)L_2) == ((float)(-1.0f)))? 1 : 0);
		goto IL_001d;
	}

IL_001c:
	{
		G_B3_0 = 1;
	}

IL_001d:
	{
		V_0 = (bool)G_B3_0;
		bool L_3 = V_0;
		if (!L_3)
		{
			goto IL_0023;
		}
	}
	{
		goto IL_0034;
	}

IL_0023:
	{
		Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* L_4;
		L_4 = Camera_get_main_m52C992F18E05355ABB9EEB64A4BF2215E12762DF(NULL);
		float L_5 = __this->___m_DefaultFarClipPlane;
		NullCheck(L_4);
		Camera_set_farClipPlane_m84EF39B09573168734613481FD979BFF31C60139(L_4, L_5, NULL);
	}

IL_0034:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AdaptiveViewDistance_OnEnabled_mE3526CC4EEFCB4C1CA8F241748C04ED251B54C3C (AdaptiveViewDistance_tC58AE1BFB8F375552BE5FE700AE912039CD69BF7* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* L_0;
		L_0 = Camera_get_main_m52C992F18E05355ABB9EEB64A4BF2215E12762DF(NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A(L_0, NULL);
		V_0 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0014;
		}
	}
	{
		goto IL_0024;
	}

IL_0014:
	{
		Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* L_3;
		L_3 = Camera_get_main_m52C992F18E05355ABB9EEB64A4BF2215E12762DF(NULL);
		NullCheck(L_3);
		float L_4;
		L_4 = Camera_get_farClipPlane_m1D7128B85B5DB866F75FBE8CEBA48335716B67BD(L_3, NULL);
		__this->___m_DefaultFarClipPlane = L_4;
	}

IL_0024:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AdaptiveViewDistance_OnLevel_m12914B6E3287E425779D7AB764B17DF2C7D4F010 (AdaptiveViewDistance_tC58AE1BFB8F375552BE5FE700AE912039CD69BF7* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	bool V_2 = false;
	{
		Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* L_0;
		L_0 = Camera_get_main_m52C992F18E05355ABB9EEB64A4BF2215E12762DF(NULL);
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Object_op_Implicit_m93896EF7D68FA113C42D3FE2BC6F661FC7EF514A(L_0, NULL);
		V_0 = (bool)((((int32_t)L_1) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_0;
		if (!L_2)
		{
			goto IL_0014;
		}
	}
	{
		goto IL_0050;
	}

IL_0014:
	{
		float L_3 = __this->___m_DefaultFarClipPlane;
		V_1 = (bool)((((float)L_3) == ((float)(-1.0f)))? 1 : 0);
		bool L_4 = V_1;
		if (!L_4)
		{
			goto IL_0035;
		}
	}
	{
		Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* L_5;
		L_5 = Camera_get_main_m52C992F18E05355ABB9EEB64A4BF2215E12762DF(NULL);
		NullCheck(L_5);
		float L_6;
		L_6 = Camera_get_farClipPlane_m1D7128B85B5DB866F75FBE8CEBA48335716B67BD(L_5, NULL);
		__this->___m_DefaultFarClipPlane = L_6;
	}

IL_0035:
	{
		bool L_7;
		L_7 = AdaptivePerformanceScaler_ScaleChanged_m8CA4C17F6CFFEE7ECBFF95720EB205A2DA01A6BE(__this, NULL);
		V_2 = L_7;
		bool L_8 = V_2;
		if (!L_8)
		{
			goto IL_0050;
		}
	}
	{
		Camera_tA92CC927D7439999BC82DBEDC0AA45B470F9E184* L_9;
		L_9 = Camera_get_main_m52C992F18E05355ABB9EEB64A4BF2215E12762DF(NULL);
		float L_10;
		L_10 = VirtualFuncInvoker0< float >::Invoke(8, __this);
		NullCheck(L_9);
		Camera_set_farClipPlane_m84EF39B09573168734613481FD979BFF31C60139(L_9, L_10, NULL);
	}

IL_0050:
	{
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AdaptiveViewDistance__ctor_mFBEDAAD1D87BB3E0068A8E18AD6820D6F00CC99E (AdaptiveViewDistance_tC58AE1BFB8F375552BE5FE700AE912039CD69BF7* __this, const RuntimeMethod* method) 
{
	{
		__this->___m_DefaultFarClipPlane = (-1.0f);
		AdaptivePerformanceScaler__ctor_m1DAA2566D0A20850A60AB246C8578D69BB93A5D5(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C void AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshal_pinvoke(const AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D& unmarshaled, AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshaled_pinvoke& marshaled)
{
	marshaled.___Name = il2cpp_codegen_marshal_string(unmarshaled.___Name);
	marshaled.___Level = unmarshaled.___Level;
}
IL2CPP_EXTERN_C void AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshal_pinvoke_back(const AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshaled_pinvoke& marshaled, AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D& unmarshaled)
{
	unmarshaled.___Name = il2cpp_codegen_marshal_string_result(marshaled.___Name);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___Name), (void*)il2cpp_codegen_marshal_string_result(marshaled.___Name));
	int32_t unmarshaledLevel_temp_1 = 0;
	unmarshaledLevel_temp_1 = marshaled.___Level;
	unmarshaled.___Level = unmarshaledLevel_temp_1;
}
IL2CPP_EXTERN_C void AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshal_pinvoke_cleanup(AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshaled_pinvoke& marshaled)
{
	il2cpp_codegen_marshal_free(marshaled.___Name);
	marshaled.___Name = NULL;
}
IL2CPP_EXTERN_C void AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshal_com(const AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D& unmarshaled, AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshaled_com& marshaled)
{
	marshaled.___Name = il2cpp_codegen_marshal_bstring(unmarshaled.___Name);
	marshaled.___Level = unmarshaled.___Level;
}
IL2CPP_EXTERN_C void AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshal_com_back(const AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshaled_com& marshaled, AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D& unmarshaled)
{
	unmarshaled.___Name = il2cpp_codegen_marshal_bstring_result(marshaled.___Name);
	Il2CppCodeGenWriteBarrier((void**)(&unmarshaled.___Name), (void*)il2cpp_codegen_marshal_bstring_result(marshaled.___Name));
	int32_t unmarshaledLevel_temp_1 = 0;
	unmarshaledLevel_temp_1 = marshaled.___Level;
	unmarshaled.___Level = unmarshaledLevel_temp_1;
}
IL2CPP_EXTERN_C void AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshal_com_cleanup(AdaptivePerformanceScalerEvent_t4FB8CAC39F9A8788AB10F7B8E579B0A4FB56558D_marshaled_com& marshaled)
{
	il2cpp_codegen_marshal_free_bstring(marshaled.___Name);
	marshaled.___Name = NULL;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C void PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshal_pinvoke(const PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83& unmarshaled, PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshaled_pinvoke& marshaled)
{
	marshaled.___U3CChangeFlagsU3Ek__BackingField = unmarshaled.___U3CChangeFlagsU3Ek__BackingField;
	marshaled.___U3CTemperatureLevelU3Ek__BackingField = unmarshaled.___U3CTemperatureLevelU3Ek__BackingField;
	marshaled.___U3CTemperatureTrendU3Ek__BackingField = unmarshaled.___U3CTemperatureTrendU3Ek__BackingField;
	marshaled.___U3CWarningLevelU3Ek__BackingField = unmarshaled.___U3CWarningLevelU3Ek__BackingField;
	marshaled.___U3CCpuPerformanceLevelU3Ek__BackingField = unmarshaled.___U3CCpuPerformanceLevelU3Ek__BackingField;
	marshaled.___U3CGpuPerformanceLevelU3Ek__BackingField = unmarshaled.___U3CGpuPerformanceLevelU3Ek__BackingField;
	marshaled.___U3CPerformanceLevelControlAvailableU3Ek__BackingField = static_cast<int32_t>(unmarshaled.___U3CPerformanceLevelControlAvailableU3Ek__BackingField);
	marshaled.___U3CCpuFrameTimeU3Ek__BackingField = unmarshaled.___U3CCpuFrameTimeU3Ek__BackingField;
	marshaled.___U3CGpuFrameTimeU3Ek__BackingField = unmarshaled.___U3CGpuFrameTimeU3Ek__BackingField;
	marshaled.___U3COverallFrameTimeU3Ek__BackingField = unmarshaled.___U3COverallFrameTimeU3Ek__BackingField;
	marshaled.___U3CCpuPerformanceBoostU3Ek__BackingField = static_cast<int32_t>(unmarshaled.___U3CCpuPerformanceBoostU3Ek__BackingField);
	marshaled.___U3CGpuPerformanceBoostU3Ek__BackingField = static_cast<int32_t>(unmarshaled.___U3CGpuPerformanceBoostU3Ek__BackingField);
	marshaled.___U3CClusterInfoU3Ek__BackingField = unmarshaled.___U3CClusterInfoU3Ek__BackingField;
	marshaled.___U3CPerformanceModeU3Ek__BackingField = unmarshaled.___U3CPerformanceModeU3Ek__BackingField;
}
IL2CPP_EXTERN_C void PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshal_pinvoke_back(const PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshaled_pinvoke& marshaled, PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83& unmarshaled)
{
	int32_t unmarshaledU3CChangeFlagsU3Ek__BackingField_temp_0 = 0;
	unmarshaledU3CChangeFlagsU3Ek__BackingField_temp_0 = marshaled.___U3CChangeFlagsU3Ek__BackingField;
	unmarshaled.___U3CChangeFlagsU3Ek__BackingField = unmarshaledU3CChangeFlagsU3Ek__BackingField_temp_0;
	float unmarshaledU3CTemperatureLevelU3Ek__BackingField_temp_1 = 0.0f;
	unmarshaledU3CTemperatureLevelU3Ek__BackingField_temp_1 = marshaled.___U3CTemperatureLevelU3Ek__BackingField;
	unmarshaled.___U3CTemperatureLevelU3Ek__BackingField = unmarshaledU3CTemperatureLevelU3Ek__BackingField_temp_1;
	float unmarshaledU3CTemperatureTrendU3Ek__BackingField_temp_2 = 0.0f;
	unmarshaledU3CTemperatureTrendU3Ek__BackingField_temp_2 = marshaled.___U3CTemperatureTrendU3Ek__BackingField;
	unmarshaled.___U3CTemperatureTrendU3Ek__BackingField = unmarshaledU3CTemperatureTrendU3Ek__BackingField_temp_2;
	int32_t unmarshaledU3CWarningLevelU3Ek__BackingField_temp_3 = 0;
	unmarshaledU3CWarningLevelU3Ek__BackingField_temp_3 = marshaled.___U3CWarningLevelU3Ek__BackingField;
	unmarshaled.___U3CWarningLevelU3Ek__BackingField = unmarshaledU3CWarningLevelU3Ek__BackingField_temp_3;
	int32_t unmarshaledU3CCpuPerformanceLevelU3Ek__BackingField_temp_4 = 0;
	unmarshaledU3CCpuPerformanceLevelU3Ek__BackingField_temp_4 = marshaled.___U3CCpuPerformanceLevelU3Ek__BackingField;
	unmarshaled.___U3CCpuPerformanceLevelU3Ek__BackingField = unmarshaledU3CCpuPerformanceLevelU3Ek__BackingField_temp_4;
	int32_t unmarshaledU3CGpuPerformanceLevelU3Ek__BackingField_temp_5 = 0;
	unmarshaledU3CGpuPerformanceLevelU3Ek__BackingField_temp_5 = marshaled.___U3CGpuPerformanceLevelU3Ek__BackingField;
	unmarshaled.___U3CGpuPerformanceLevelU3Ek__BackingField = unmarshaledU3CGpuPerformanceLevelU3Ek__BackingField_temp_5;
	bool unmarshaledU3CPerformanceLevelControlAvailableU3Ek__BackingField_temp_6 = false;
	unmarshaledU3CPerformanceLevelControlAvailableU3Ek__BackingField_temp_6 = static_cast<bool>(marshaled.___U3CPerformanceLevelControlAvailableU3Ek__BackingField);
	unmarshaled.___U3CPerformanceLevelControlAvailableU3Ek__BackingField = unmarshaledU3CPerformanceLevelControlAvailableU3Ek__BackingField_temp_6;
	float unmarshaledU3CCpuFrameTimeU3Ek__BackingField_temp_7 = 0.0f;
	unmarshaledU3CCpuFrameTimeU3Ek__BackingField_temp_7 = marshaled.___U3CCpuFrameTimeU3Ek__BackingField;
	unmarshaled.___U3CCpuFrameTimeU3Ek__BackingField = unmarshaledU3CCpuFrameTimeU3Ek__BackingField_temp_7;
	float unmarshaledU3CGpuFrameTimeU3Ek__BackingField_temp_8 = 0.0f;
	unmarshaledU3CGpuFrameTimeU3Ek__BackingField_temp_8 = marshaled.___U3CGpuFrameTimeU3Ek__BackingField;
	unmarshaled.___U3CGpuFrameTimeU3Ek__BackingField = unmarshaledU3CGpuFrameTimeU3Ek__BackingField_temp_8;
	float unmarshaledU3COverallFrameTimeU3Ek__BackingField_temp_9 = 0.0f;
	unmarshaledU3COverallFrameTimeU3Ek__BackingField_temp_9 = marshaled.___U3COverallFrameTimeU3Ek__BackingField;
	unmarshaled.___U3COverallFrameTimeU3Ek__BackingField = unmarshaledU3COverallFrameTimeU3Ek__BackingField_temp_9;
	bool unmarshaledU3CCpuPerformanceBoostU3Ek__BackingField_temp_10 = false;
	unmarshaledU3CCpuPerformanceBoostU3Ek__BackingField_temp_10 = static_cast<bool>(marshaled.___U3CCpuPerformanceBoostU3Ek__BackingField);
	unmarshaled.___U3CCpuPerformanceBoostU3Ek__BackingField = unmarshaledU3CCpuPerformanceBoostU3Ek__BackingField_temp_10;
	bool unmarshaledU3CGpuPerformanceBoostU3Ek__BackingField_temp_11 = false;
	unmarshaledU3CGpuPerformanceBoostU3Ek__BackingField_temp_11 = static_cast<bool>(marshaled.___U3CGpuPerformanceBoostU3Ek__BackingField);
	unmarshaled.___U3CGpuPerformanceBoostU3Ek__BackingField = unmarshaledU3CGpuPerformanceBoostU3Ek__BackingField_temp_11;
	ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 unmarshaledU3CClusterInfoU3Ek__BackingField_temp_12;
	memset((&unmarshaledU3CClusterInfoU3Ek__BackingField_temp_12), 0, sizeof(unmarshaledU3CClusterInfoU3Ek__BackingField_temp_12));
	unmarshaledU3CClusterInfoU3Ek__BackingField_temp_12 = marshaled.___U3CClusterInfoU3Ek__BackingField;
	unmarshaled.___U3CClusterInfoU3Ek__BackingField = unmarshaledU3CClusterInfoU3Ek__BackingField_temp_12;
	int32_t unmarshaledU3CPerformanceModeU3Ek__BackingField_temp_13 = 0;
	unmarshaledU3CPerformanceModeU3Ek__BackingField_temp_13 = marshaled.___U3CPerformanceModeU3Ek__BackingField;
	unmarshaled.___U3CPerformanceModeU3Ek__BackingField = unmarshaledU3CPerformanceModeU3Ek__BackingField_temp_13;
}
IL2CPP_EXTERN_C void PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshal_pinvoke_cleanup(PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshaled_pinvoke& marshaled)
{
}
IL2CPP_EXTERN_C void PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshal_com(const PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83& unmarshaled, PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshaled_com& marshaled)
{
	marshaled.___U3CChangeFlagsU3Ek__BackingField = unmarshaled.___U3CChangeFlagsU3Ek__BackingField;
	marshaled.___U3CTemperatureLevelU3Ek__BackingField = unmarshaled.___U3CTemperatureLevelU3Ek__BackingField;
	marshaled.___U3CTemperatureTrendU3Ek__BackingField = unmarshaled.___U3CTemperatureTrendU3Ek__BackingField;
	marshaled.___U3CWarningLevelU3Ek__BackingField = unmarshaled.___U3CWarningLevelU3Ek__BackingField;
	marshaled.___U3CCpuPerformanceLevelU3Ek__BackingField = unmarshaled.___U3CCpuPerformanceLevelU3Ek__BackingField;
	marshaled.___U3CGpuPerformanceLevelU3Ek__BackingField = unmarshaled.___U3CGpuPerformanceLevelU3Ek__BackingField;
	marshaled.___U3CPerformanceLevelControlAvailableU3Ek__BackingField = static_cast<int32_t>(unmarshaled.___U3CPerformanceLevelControlAvailableU3Ek__BackingField);
	marshaled.___U3CCpuFrameTimeU3Ek__BackingField = unmarshaled.___U3CCpuFrameTimeU3Ek__BackingField;
	marshaled.___U3CGpuFrameTimeU3Ek__BackingField = unmarshaled.___U3CGpuFrameTimeU3Ek__BackingField;
	marshaled.___U3COverallFrameTimeU3Ek__BackingField = unmarshaled.___U3COverallFrameTimeU3Ek__BackingField;
	marshaled.___U3CCpuPerformanceBoostU3Ek__BackingField = static_cast<int32_t>(unmarshaled.___U3CCpuPerformanceBoostU3Ek__BackingField);
	marshaled.___U3CGpuPerformanceBoostU3Ek__BackingField = static_cast<int32_t>(unmarshaled.___U3CGpuPerformanceBoostU3Ek__BackingField);
	marshaled.___U3CClusterInfoU3Ek__BackingField = unmarshaled.___U3CClusterInfoU3Ek__BackingField;
	marshaled.___U3CPerformanceModeU3Ek__BackingField = unmarshaled.___U3CPerformanceModeU3Ek__BackingField;
}
IL2CPP_EXTERN_C void PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshal_com_back(const PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshaled_com& marshaled, PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83& unmarshaled)
{
	int32_t unmarshaledU3CChangeFlagsU3Ek__BackingField_temp_0 = 0;
	unmarshaledU3CChangeFlagsU3Ek__BackingField_temp_0 = marshaled.___U3CChangeFlagsU3Ek__BackingField;
	unmarshaled.___U3CChangeFlagsU3Ek__BackingField = unmarshaledU3CChangeFlagsU3Ek__BackingField_temp_0;
	float unmarshaledU3CTemperatureLevelU3Ek__BackingField_temp_1 = 0.0f;
	unmarshaledU3CTemperatureLevelU3Ek__BackingField_temp_1 = marshaled.___U3CTemperatureLevelU3Ek__BackingField;
	unmarshaled.___U3CTemperatureLevelU3Ek__BackingField = unmarshaledU3CTemperatureLevelU3Ek__BackingField_temp_1;
	float unmarshaledU3CTemperatureTrendU3Ek__BackingField_temp_2 = 0.0f;
	unmarshaledU3CTemperatureTrendU3Ek__BackingField_temp_2 = marshaled.___U3CTemperatureTrendU3Ek__BackingField;
	unmarshaled.___U3CTemperatureTrendU3Ek__BackingField = unmarshaledU3CTemperatureTrendU3Ek__BackingField_temp_2;
	int32_t unmarshaledU3CWarningLevelU3Ek__BackingField_temp_3 = 0;
	unmarshaledU3CWarningLevelU3Ek__BackingField_temp_3 = marshaled.___U3CWarningLevelU3Ek__BackingField;
	unmarshaled.___U3CWarningLevelU3Ek__BackingField = unmarshaledU3CWarningLevelU3Ek__BackingField_temp_3;
	int32_t unmarshaledU3CCpuPerformanceLevelU3Ek__BackingField_temp_4 = 0;
	unmarshaledU3CCpuPerformanceLevelU3Ek__BackingField_temp_4 = marshaled.___U3CCpuPerformanceLevelU3Ek__BackingField;
	unmarshaled.___U3CCpuPerformanceLevelU3Ek__BackingField = unmarshaledU3CCpuPerformanceLevelU3Ek__BackingField_temp_4;
	int32_t unmarshaledU3CGpuPerformanceLevelU3Ek__BackingField_temp_5 = 0;
	unmarshaledU3CGpuPerformanceLevelU3Ek__BackingField_temp_5 = marshaled.___U3CGpuPerformanceLevelU3Ek__BackingField;
	unmarshaled.___U3CGpuPerformanceLevelU3Ek__BackingField = unmarshaledU3CGpuPerformanceLevelU3Ek__BackingField_temp_5;
	bool unmarshaledU3CPerformanceLevelControlAvailableU3Ek__BackingField_temp_6 = false;
	unmarshaledU3CPerformanceLevelControlAvailableU3Ek__BackingField_temp_6 = static_cast<bool>(marshaled.___U3CPerformanceLevelControlAvailableU3Ek__BackingField);
	unmarshaled.___U3CPerformanceLevelControlAvailableU3Ek__BackingField = unmarshaledU3CPerformanceLevelControlAvailableU3Ek__BackingField_temp_6;
	float unmarshaledU3CCpuFrameTimeU3Ek__BackingField_temp_7 = 0.0f;
	unmarshaledU3CCpuFrameTimeU3Ek__BackingField_temp_7 = marshaled.___U3CCpuFrameTimeU3Ek__BackingField;
	unmarshaled.___U3CCpuFrameTimeU3Ek__BackingField = unmarshaledU3CCpuFrameTimeU3Ek__BackingField_temp_7;
	float unmarshaledU3CGpuFrameTimeU3Ek__BackingField_temp_8 = 0.0f;
	unmarshaledU3CGpuFrameTimeU3Ek__BackingField_temp_8 = marshaled.___U3CGpuFrameTimeU3Ek__BackingField;
	unmarshaled.___U3CGpuFrameTimeU3Ek__BackingField = unmarshaledU3CGpuFrameTimeU3Ek__BackingField_temp_8;
	float unmarshaledU3COverallFrameTimeU3Ek__BackingField_temp_9 = 0.0f;
	unmarshaledU3COverallFrameTimeU3Ek__BackingField_temp_9 = marshaled.___U3COverallFrameTimeU3Ek__BackingField;
	unmarshaled.___U3COverallFrameTimeU3Ek__BackingField = unmarshaledU3COverallFrameTimeU3Ek__BackingField_temp_9;
	bool unmarshaledU3CCpuPerformanceBoostU3Ek__BackingField_temp_10 = false;
	unmarshaledU3CCpuPerformanceBoostU3Ek__BackingField_temp_10 = static_cast<bool>(marshaled.___U3CCpuPerformanceBoostU3Ek__BackingField);
	unmarshaled.___U3CCpuPerformanceBoostU3Ek__BackingField = unmarshaledU3CCpuPerformanceBoostU3Ek__BackingField_temp_10;
	bool unmarshaledU3CGpuPerformanceBoostU3Ek__BackingField_temp_11 = false;
	unmarshaledU3CGpuPerformanceBoostU3Ek__BackingField_temp_11 = static_cast<bool>(marshaled.___U3CGpuPerformanceBoostU3Ek__BackingField);
	unmarshaled.___U3CGpuPerformanceBoostU3Ek__BackingField = unmarshaledU3CGpuPerformanceBoostU3Ek__BackingField_temp_11;
	ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 unmarshaledU3CClusterInfoU3Ek__BackingField_temp_12;
	memset((&unmarshaledU3CClusterInfoU3Ek__BackingField_temp_12), 0, sizeof(unmarshaledU3CClusterInfoU3Ek__BackingField_temp_12));
	unmarshaledU3CClusterInfoU3Ek__BackingField_temp_12 = marshaled.___U3CClusterInfoU3Ek__BackingField;
	unmarshaled.___U3CClusterInfoU3Ek__BackingField = unmarshaledU3CClusterInfoU3Ek__BackingField_temp_12;
	int32_t unmarshaledU3CPerformanceModeU3Ek__BackingField_temp_13 = 0;
	unmarshaledU3CPerformanceModeU3Ek__BackingField_temp_13 = marshaled.___U3CPerformanceModeU3Ek__BackingField;
	unmarshaled.___U3CPerformanceModeU3Ek__BackingField = unmarshaledU3CPerformanceModeU3Ek__BackingField_temp_13;
}
IL2CPP_EXTERN_C void PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshal_com_cleanup(PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83_marshaled_com& marshaled)
{
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_ChangeFlags_m83DE31AF3877A2A1507A6703B190533FD166B9B7 (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CChangeFlagsU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t PerformanceDataRecord_get_ChangeFlags_m83DE31AF3877A2A1507A6703B190533FD166B9B7_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = PerformanceDataRecord_get_ChangeFlags_m83DE31AF3877A2A1507A6703B190533FD166B9B7_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_TemperatureLevel_mF48F6ECD619E7DD65811410891B4AB7B9B218865 (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___U3CTemperatureLevelU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  float PerformanceDataRecord_get_TemperatureLevel_mF48F6ECD619E7DD65811410891B4AB7B9B218865_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	float _returnValue;
	_returnValue = PerformanceDataRecord_get_TemperatureLevel_mF48F6ECD619E7DD65811410891B4AB7B9B218865_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_TemperatureTrend_mF1A3DF7A654F1A20A4D9A70647B4250E734D6467 (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___U3CTemperatureTrendU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  float PerformanceDataRecord_get_TemperatureTrend_mF1A3DF7A654F1A20A4D9A70647B4250E734D6467_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	float _returnValue;
	_returnValue = PerformanceDataRecord_get_TemperatureTrend_mF1A3DF7A654F1A20A4D9A70647B4250E734D6467_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_WarningLevel_m0C061FD490DF445A1D1347DBC5F798B206B5DB35 (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CWarningLevelU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t PerformanceDataRecord_get_WarningLevel_m0C061FD490DF445A1D1347DBC5F798B206B5DB35_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = PerformanceDataRecord_get_WarningLevel_m0C061FD490DF445A1D1347DBC5F798B206B5DB35_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_CpuPerformanceLevel_mF688EC621C77916A86F96CF7D0DAFD520B6D68E8 (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CCpuPerformanceLevelU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t PerformanceDataRecord_get_CpuPerformanceLevel_mF688EC621C77916A86F96CF7D0DAFD520B6D68E8_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = PerformanceDataRecord_get_CpuPerformanceLevel_mF688EC621C77916A86F96CF7D0DAFD520B6D68E8_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_GpuPerformanceLevel_mA928B60EF914AB4E7D95291E1357A3FE795DBE23 (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CGpuPerformanceLevelU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t PerformanceDataRecord_get_GpuPerformanceLevel_mA928B60EF914AB4E7D95291E1357A3FE795DBE23_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = PerformanceDataRecord_get_GpuPerformanceLevel_mA928B60EF914AB4E7D95291E1357A3FE795DBE23_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PerformanceDataRecord_get_PerformanceLevelControlAvailable_mB2379A58631D8AAE1AE389560BF46951ABE7D80F (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CPerformanceLevelControlAvailableU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  bool PerformanceDataRecord_get_PerformanceLevelControlAvailable_mB2379A58631D8AAE1AE389560BF46951ABE7D80F_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	bool _returnValue;
	_returnValue = PerformanceDataRecord_get_PerformanceLevelControlAvailable_mB2379A58631D8AAE1AE389560BF46951ABE7D80F_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_CpuFrameTime_m64C3D3C8D2D7F3670DCC3EE2026B805DADF614BE (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___U3CCpuFrameTimeU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  float PerformanceDataRecord_get_CpuFrameTime_m64C3D3C8D2D7F3670DCC3EE2026B805DADF614BE_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	float _returnValue;
	_returnValue = PerformanceDataRecord_get_CpuFrameTime_m64C3D3C8D2D7F3670DCC3EE2026B805DADF614BE_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_GpuFrameTime_mFA20351C75C59AF7861FCE6E9A859AE0FD75C767 (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___U3CGpuFrameTimeU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  float PerformanceDataRecord_get_GpuFrameTime_mFA20351C75C59AF7861FCE6E9A859AE0FD75C767_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	float _returnValue;
	_returnValue = PerformanceDataRecord_get_GpuFrameTime_mFA20351C75C59AF7861FCE6E9A859AE0FD75C767_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_OverallFrameTime_m6ABDF5F1B04E6FF9BDD96AFA00844F84E6570D90 (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___U3COverallFrameTimeU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  float PerformanceDataRecord_get_OverallFrameTime_m6ABDF5F1B04E6FF9BDD96AFA00844F84E6570D90_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	float _returnValue;
	_returnValue = PerformanceDataRecord_get_OverallFrameTime_m6ABDF5F1B04E6FF9BDD96AFA00844F84E6570D90_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PerformanceDataRecord_get_CpuPerformanceBoost_m55A78568F8E19144717C3CEC17CE90FA766591D2 (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CCpuPerformanceBoostU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  bool PerformanceDataRecord_get_CpuPerformanceBoost_m55A78568F8E19144717C3CEC17CE90FA766591D2_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	bool _returnValue;
	_returnValue = PerformanceDataRecord_get_CpuPerformanceBoost_m55A78568F8E19144717C3CEC17CE90FA766591D2_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PerformanceDataRecord_get_GpuPerformanceBoost_mFD01BBFC9A9BE53ED81947089A02691635789B7E (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CGpuPerformanceBoostU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  bool PerformanceDataRecord_get_GpuPerformanceBoost_mFD01BBFC9A9BE53ED81947089A02691635789B7E_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	bool _returnValue;
	_returnValue = PerformanceDataRecord_get_GpuPerformanceBoost_mFD01BBFC9A9BE53ED81947089A02691635789B7E_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 PerformanceDataRecord_get_ClusterInfo_m6EC3F093AE1024050D8C7FEAECCC7153668CB187 (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 L_0 = __this->___U3CClusterInfoU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 PerformanceDataRecord_get_ClusterInfo_m6EC3F093AE1024050D8C7FEAECCC7153668CB187_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 _returnValue;
	_returnValue = PerformanceDataRecord_get_ClusterInfo_m6EC3F093AE1024050D8C7FEAECCC7153668CB187_inline(_thisAdjusted, method);
	return _returnValue;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_PerformanceMode_mEF911B8B3207795B86E013D3DFF2679A599D78DF (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CPerformanceModeU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C  int32_t PerformanceDataRecord_get_PerformanceMode_mEF911B8B3207795B86E013D3DFF2679A599D78DF_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83*>(__this + _offset);
	int32_t _returnValue;
	_returnValue = PerformanceDataRecord_get_PerformanceMode_mEF911B8B3207795B86E013D3DFF2679A599D78DF_inline(_thisAdjusted, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AdaptivePerformanceSubsystem__ctor_mEEBD3B76AC04711B8088F2E55218C832F490A078 (AdaptivePerformanceSubsystem_t2D41A24C328589A3018DA0478476D2591E9B5C23* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AdaptivePerformanceSubsystemBase_3__ctor_mC0ACA968EAB84D845C73965E57A907FC1F7351C7_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		AdaptivePerformanceSubsystemBase_3__ctor_mC0ACA968EAB84D845C73965E57A907FC1F7351C7(__this, AdaptivePerformanceSubsystemBase_3__ctor_mC0ACA968EAB84D845C73965E57A907FC1F7351C7_RuntimeMethod_var);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* AdaptivePerformanceSubsystem_get_ApplicationLifecycle_m390731F9A4E5410AF70F93D18E9BD5DE3E49B34E (AdaptivePerformanceSubsystem_t2D41A24C328589A3018DA0478476D2591E9B5C23* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* L_0;
		L_0 = SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_inline(__this, SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = VirtualFuncInvoker0< RuntimeObject* >::Invoke(8, L_0);
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* AdaptivePerformanceSubsystem_get_PerformanceLevelControl_m594BBC140BF7A1AC252D8B42121D318B6723AC99 (AdaptivePerformanceSubsystem_t2D41A24C328589A3018DA0478476D2591E9B5C23* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* L_0;
		L_0 = SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_inline(__this, SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		NullCheck(L_0);
		RuntimeObject* L_1;
		L_1 = VirtualFuncInvoker0< RuntimeObject* >::Invoke(9, L_0);
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Version_tE426DB5655D0F22920AE16A2AA9AB7781B8255A7* AdaptivePerformanceSubsystem_get_Version_m41B1F31D0DAE3122C8464A818CEF430CF9AA97BB (AdaptivePerformanceSubsystem_t2D41A24C328589A3018DA0478476D2591E9B5C23* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* L_0;
		L_0 = SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_inline(__this, SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		NullCheck(L_0);
		Version_tE426DB5655D0F22920AE16A2AA9AB7781B8255A7* L_1;
		L_1 = VirtualFuncInvoker0< Version_tE426DB5655D0F22920AE16A2AA9AB7781B8255A7* >::Invoke(10, L_0);
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AdaptivePerformanceSubsystem_get_Capabilities_m3B41A455C5EF85D90A6796AE764E6285E1AF21A1 (AdaptivePerformanceSubsystem_t2D41A24C328589A3018DA0478476D2591E9B5C23* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* L_0;
		L_0 = SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_inline(__this, SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		NullCheck(L_0);
		int32_t L_1;
		L_1 = VirtualFuncInvoker0< int32_t >::Invoke(6, L_0);
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* AdaptivePerformanceSubsystem_get_Stats_m77F1C4119D96380224202D25641B051E500C1C75 (AdaptivePerformanceSubsystem_t2D41A24C328589A3018DA0478476D2591E9B5C23* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* L_0;
		L_0 = SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_inline(__this, SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		NullCheck(L_0);
		String_t* L_1;
		L_1 = VirtualFuncInvoker0< String_t* >::Invoke(11, L_0);
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AdaptivePerformanceSubsystem_get_Initialized_m03F5BEE53ABC7A5234EAA16864C041ED05F2BF90 (AdaptivePerformanceSubsystem_t2D41A24C328589A3018DA0478476D2591E9B5C23* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* L_0;
		L_0 = SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_inline(__this, SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		NullCheck(L_0);
		bool L_1;
		L_1 = VirtualFuncInvoker0< bool >::Invoke(12, L_0);
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83 AdaptivePerformanceSubsystem_Update_m7A9E8A2B7B2DB8BAE0C973AF3289B2C497430E11 (AdaptivePerformanceSubsystem_t2D41A24C328589A3018DA0478476D2591E9B5C23* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83 V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* L_0;
		L_0 = SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_inline(__this, SubsystemWithProvider_3_get_provider_mCF636A49386C401A0EA266DC4901D5E5DFADB851_RuntimeMethod_var);
		NullCheck(L_0);
		PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83 L_1;
		L_1 = VirtualFuncInvoker0< PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83 >::Invoke(7, L_0);
		V_0 = L_1;
		goto IL_000f;
	}

IL_000f:
	{
		PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83 L_2 = V_0;
		return L_2;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* APProvider_get_Stats_m5D2D7423E1DE1B78F54C7F549D0B2D6B4B064105 (APProvider_tCF914DB0FD4F4EB3579452C06E1D8AB02501B998* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		V_0 = _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709;
		goto IL_0009;
	}

IL_0009:
	{
		String_t* L_0 = V_0;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C void Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshal_pinvoke(const Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB& unmarshaled, Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshaled_pinvoke& marshaled)
{
	Exception_t* ___U3CproviderTypeU3Ek__BackingFieldException = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<providerType>k__BackingField' of type 'Cinfo': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CproviderTypeU3Ek__BackingFieldException, NULL);
}
IL2CPP_EXTERN_C void Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshal_pinvoke_back(const Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshaled_pinvoke& marshaled, Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB& unmarshaled)
{
	Exception_t* ___U3CproviderTypeU3Ek__BackingFieldException = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<providerType>k__BackingField' of type 'Cinfo': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CproviderTypeU3Ek__BackingFieldException, NULL);
}
IL2CPP_EXTERN_C void Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshal_pinvoke_cleanup(Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshaled_pinvoke& marshaled)
{
}
IL2CPP_EXTERN_C void Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshal_com(const Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB& unmarshaled, Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshaled_com& marshaled)
{
	Exception_t* ___U3CproviderTypeU3Ek__BackingFieldException = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<providerType>k__BackingField' of type 'Cinfo': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CproviderTypeU3Ek__BackingFieldException, NULL);
}
IL2CPP_EXTERN_C void Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshal_com_back(const Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshaled_com& marshaled, Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB& unmarshaled)
{
	Exception_t* ___U3CproviderTypeU3Ek__BackingFieldException = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '<providerType>k__BackingField' of type 'Cinfo': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(___U3CproviderTypeU3Ek__BackingFieldException, NULL);
}
IL2CPP_EXTERN_C void Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshal_com_cleanup(Cinfo_t016018D78B642CAAA7B595015B8AF98E5F1008DB_marshaled_com& marshaled)
{
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_ChangeFlags_m83DE31AF3877A2A1507A6703B190533FD166B9B7_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CChangeFlagsU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_TemperatureLevel_mF48F6ECD619E7DD65811410891B4AB7B9B218865_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___U3CTemperatureLevelU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_TemperatureTrend_mF1A3DF7A654F1A20A4D9A70647B4250E734D6467_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___U3CTemperatureTrendU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_WarningLevel_m0C061FD490DF445A1D1347DBC5F798B206B5DB35_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CWarningLevelU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_CpuPerformanceLevel_mF688EC621C77916A86F96CF7D0DAFD520B6D68E8_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CCpuPerformanceLevelU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_GpuPerformanceLevel_mA928B60EF914AB4E7D95291E1357A3FE795DBE23_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CGpuPerformanceLevelU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool PerformanceDataRecord_get_PerformanceLevelControlAvailable_mB2379A58631D8AAE1AE389560BF46951ABE7D80F_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CPerformanceLevelControlAvailableU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_CpuFrameTime_m64C3D3C8D2D7F3670DCC3EE2026B805DADF614BE_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___U3CCpuFrameTimeU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_GpuFrameTime_mFA20351C75C59AF7861FCE6E9A859AE0FD75C767_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___U3CGpuFrameTimeU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float PerformanceDataRecord_get_OverallFrameTime_m6ABDF5F1B04E6FF9BDD96AFA00844F84E6570D90_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		float L_0 = __this->___U3COverallFrameTimeU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool PerformanceDataRecord_get_CpuPerformanceBoost_m55A78568F8E19144717C3CEC17CE90FA766591D2_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CCpuPerformanceBoostU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool PerformanceDataRecord_get_GpuPerformanceBoost_mFD01BBFC9A9BE53ED81947089A02691635789B7E_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___U3CGpuPerformanceBoostU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 PerformanceDataRecord_get_ClusterInfo_m6EC3F093AE1024050D8C7FEAECCC7153668CB187_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		ClusterInfo_tE84F530B1972D0F8712CD136B14D4C4136B0BA15 L_0 = __this->___U3CClusterInfoU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t PerformanceDataRecord_get_PerformanceMode_mEF911B8B3207795B86E013D3DFF2679A599D78DF_inline (PerformanceDataRecord_tDF1B7607FB8378B49C42DFFA5AE4A64F62C42F83* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CPerformanceModeU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* SubsystemWithProvider_3_get_provider_m963D70D839CE42A2C17A2C183A61C25F0E2C6732_gshared_inline (SubsystemWithProvider_3_t548D9C2A4778C7ADB62496A2A07F8B7563309893* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CproviderU3Ek__BackingField;
		return L_0;
	}
}
