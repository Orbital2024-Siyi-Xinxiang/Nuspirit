extern "C" void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_SharedInternals();
	RegisterModule_SharedInternals();

	void RegisterModule_Core();
	RegisterModule_Core();

	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_AssetBundle();
	RegisterModule_AssetBundle();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_GameCenter();
	RegisterModule_GameCenter();

	void RegisterModule_GraphicsStateCollectionSerializer();
	RegisterModule_GraphicsStateCollectionSerializer();

	void RegisterModule_Grid();
	RegisterModule_Grid();

	void RegisterModule_HierarchyCore();
	RegisterModule_HierarchyCore();

	void RegisterModule_HotReload();
	RegisterModule_HotReload();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_ImageConversion();
	RegisterModule_ImageConversion();

	void RegisterModule_Input();
	RegisterModule_Input();

	void RegisterModule_InputLegacy();
	RegisterModule_InputLegacy();

	void RegisterModule_InputForUI();
	RegisterModule_InputForUI();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

	void RegisterModule_Physics();
	RegisterModule_Physics();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_Properties();
	RegisterModule_Properties();

	void RegisterModule_RuntimeInitializeOnLoadManagerInitializer();
	RegisterModule_RuntimeInitializeOnLoadManagerInitializer();

	void RegisterModule_Subsystems();
	RegisterModule_Subsystems();

	void RegisterModule_TLS();
	RegisterModule_TLS();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_TextCoreFontEngine();
	RegisterModule_TextCoreFontEngine();

	void RegisterModule_TextCoreTextEngine();
	RegisterModule_TextCoreTextEngine();

	void RegisterModule_Tilemap();
	RegisterModule_Tilemap();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_UIElements();
	RegisterModule_UIElements();

	void RegisterModule_UnityAnalyticsCommon();
	RegisterModule_UnityAnalyticsCommon();

	void RegisterModule_UnityWebRequest();
	RegisterModule_UnityWebRequest();

	void RegisterModule_UnityWebRequestAssetBundle();
	RegisterModule_UnityWebRequestAssetBundle();

	void RegisterModule_UnityWebRequestTexture();
	RegisterModule_UnityWebRequestTexture();

	void RegisterModule_XR();
	RegisterModule_XR();

	void RegisterModule_VR();
	RegisterModule_VR();

}

template <typename T> void RegisterUnityClass(const char*);
template <typename T> void RegisterStrippedType(int, const char*, const char*);

void InvokeRegisterStaticallyLinkedModuleClasses()
{
	// Do nothing (we're in stripping mode)
}

class AnimationClip; template <> void RegisterUnityClass<AnimationClip>(const char*);
class Animator; template <> void RegisterUnityClass<Animator>(const char*);
class AnimatorController; template <> void RegisterUnityClass<AnimatorController>(const char*);
class AnimatorOverrideController; template <> void RegisterUnityClass<AnimatorOverrideController>(const char*);
class Motion; template <> void RegisterUnityClass<Motion>(const char*);
class RuntimeAnimatorController; template <> void RegisterUnityClass<RuntimeAnimatorController>(const char*);
class AssetBundle; template <> void RegisterUnityClass<AssetBundle>(const char*);
class AudioBehaviour; template <> void RegisterUnityClass<AudioBehaviour>(const char*);
class AudioClip; template <> void RegisterUnityClass<AudioClip>(const char*);
class AudioListener; template <> void RegisterUnityClass<AudioListener>(const char*);
class AudioManager; template <> void RegisterUnityClass<AudioManager>(const char*);
class AudioResource; template <> void RegisterUnityClass<AudioResource>(const char*);
class SampleClip; template <> void RegisterUnityClass<SampleClip>(const char*);
class Behaviour; template <> void RegisterUnityClass<Behaviour>(const char*);
class BuildSettings; template <> void RegisterUnityClass<BuildSettings>(const char*);
class Camera; template <> void RegisterUnityClass<Camera>(const char*);
namespace Unity { class Component; } template <> void RegisterUnityClass<Unity::Component>(const char*);
class ComputeShader; template <> void RegisterUnityClass<ComputeShader>(const char*);
class Cubemap; template <> void RegisterUnityClass<Cubemap>(const char*);
class CubemapArray; template <> void RegisterUnityClass<CubemapArray>(const char*);
class DelayedCallManager; template <> void RegisterUnityClass<DelayedCallManager>(const char*);
class EditorExtension; template <> void RegisterUnityClass<EditorExtension>(const char*);
class GameManager; template <> void RegisterUnityClass<GameManager>(const char*);
class GameObject; template <> void RegisterUnityClass<GameObject>(const char*);
class GlobalGameManager; template <> void RegisterUnityClass<GlobalGameManager>(const char*);
class GraphicsSettings; template <> void RegisterUnityClass<GraphicsSettings>(const char*);
class InputManager; template <> void RegisterUnityClass<InputManager>(const char*);
class LevelGameManager; template <> void RegisterUnityClass<LevelGameManager>(const char*);
class Light; template <> void RegisterUnityClass<Light>(const char*);
class LightProbes; template <> void RegisterUnityClass<LightProbes>(const char*);
class LightingSettings; template <> void RegisterUnityClass<LightingSettings>(const char*);
class LightmapSettings; template <> void RegisterUnityClass<LightmapSettings>(const char*);
class LowerResBlitTexture; template <> void RegisterUnityClass<LowerResBlitTexture>(const char*);
class Material; template <> void RegisterUnityClass<Material>(const char*);
class Mesh; template <> void RegisterUnityClass<Mesh>(const char*);
class MeshFilter; template <> void RegisterUnityClass<MeshFilter>(const char*);
class MeshRenderer; template <> void RegisterUnityClass<MeshRenderer>(const char*);
class MonoBehaviour; template <> void RegisterUnityClass<MonoBehaviour>(const char*);
class MonoManager; template <> void RegisterUnityClass<MonoManager>(const char*);
class MonoScript; template <> void RegisterUnityClass<MonoScript>(const char*);
class NamedObject; template <> void RegisterUnityClass<NamedObject>(const char*);
class Object; template <> void RegisterUnityClass<Object>(const char*);
class PlayerSettings; template <> void RegisterUnityClass<PlayerSettings>(const char*);
class PreloadData; template <> void RegisterUnityClass<PreloadData>(const char*);
class QualitySettings; template <> void RegisterUnityClass<QualitySettings>(const char*);
namespace UI { class RectTransform; } template <> void RegisterUnityClass<UI::RectTransform>(const char*);
class ReflectionProbe; template <> void RegisterUnityClass<ReflectionProbe>(const char*);
class RenderSettings; template <> void RegisterUnityClass<RenderSettings>(const char*);
class RenderTexture; template <> void RegisterUnityClass<RenderTexture>(const char*);
class Renderer; template <> void RegisterUnityClass<Renderer>(const char*);
class ResourceManager; template <> void RegisterUnityClass<ResourceManager>(const char*);
class RuntimeInitializeOnLoadManager; template <> void RegisterUnityClass<RuntimeInitializeOnLoadManager>(const char*);
class Shader; template <> void RegisterUnityClass<Shader>(const char*);
class ShaderNameRegistry; template <> void RegisterUnityClass<ShaderNameRegistry>(const char*);
class SortingGroup; template <> void RegisterUnityClass<SortingGroup>(const char*);
class Sprite; template <> void RegisterUnityClass<Sprite>(const char*);
class SpriteAtlas; template <> void RegisterUnityClass<SpriteAtlas>(const char*);
class SpriteRenderer; template <> void RegisterUnityClass<SpriteRenderer>(const char*);
class TagManager; template <> void RegisterUnityClass<TagManager>(const char*);
class TextAsset; template <> void RegisterUnityClass<TextAsset>(const char*);
class Texture; template <> void RegisterUnityClass<Texture>(const char*);
class Texture2D; template <> void RegisterUnityClass<Texture2D>(const char*);
class Texture2DArray; template <> void RegisterUnityClass<Texture2DArray>(const char*);
class Texture3D; template <> void RegisterUnityClass<Texture3D>(const char*);
class TimeManager; template <> void RegisterUnityClass<TimeManager>(const char*);
class Transform; template <> void RegisterUnityClass<Transform>(const char*);
class Grid; template <> void RegisterUnityClass<Grid>(const char*);
class GridLayout; template <> void RegisterUnityClass<GridLayout>(const char*);
class Collider; template <> void RegisterUnityClass<Collider>(const char*);
class PhysicsManager; template <> void RegisterUnityClass<PhysicsManager>(const char*);
class Rigidbody; template <> void RegisterUnityClass<Rigidbody>(const char*);
class BoxCollider2D; template <> void RegisterUnityClass<BoxCollider2D>(const char*);
class Collider2D; template <> void RegisterUnityClass<Collider2D>(const char*);
class CompositeCollider2D; template <> void RegisterUnityClass<CompositeCollider2D>(const char*);
class Physics2DSettings; template <> void RegisterUnityClass<Physics2DSettings>(const char*);
class Rigidbody2D; template <> void RegisterUnityClass<Rigidbody2D>(const char*);
namespace TextRendering { class Font; } template <> void RegisterUnityClass<TextRendering::Font>(const char*);
namespace TextRenderingPrivate { class TextMesh; } template <> void RegisterUnityClass<TextRenderingPrivate::TextMesh>(const char*);
class Tilemap; template <> void RegisterUnityClass<Tilemap>(const char*);
class TilemapCollider2D; template <> void RegisterUnityClass<TilemapCollider2D>(const char*);
class TilemapRenderer; template <> void RegisterUnityClass<TilemapRenderer>(const char*);
namespace UI { class Canvas; } template <> void RegisterUnityClass<UI::Canvas>(const char*);
namespace UI { class CanvasGroup; } template <> void RegisterUnityClass<UI::CanvasGroup>(const char*);
namespace UI { class CanvasRenderer; } template <> void RegisterUnityClass<UI::CanvasRenderer>(const char*);
class UIRenderer; template <> void RegisterUnityClass<UIRenderer>(const char*);

void RegisterAllClasses()
{
void RegisterBuiltinTypes();
RegisterBuiltinTypes();
	//Total: 85 non stripped classes
	//0. AnimationClip
	RegisterUnityClass<AnimationClip>("Animation");
	//1. Animator
	RegisterUnityClass<Animator>("Animation");
	//2. AnimatorController
	RegisterUnityClass<AnimatorController>("Animation");
	//3. AnimatorOverrideController
	RegisterUnityClass<AnimatorOverrideController>("Animation");
	//4. Motion
	RegisterUnityClass<Motion>("Animation");
	//5. RuntimeAnimatorController
	RegisterUnityClass<RuntimeAnimatorController>("Animation");
	//6. AssetBundle
	RegisterUnityClass<AssetBundle>("AssetBundle");
	//7. AudioBehaviour
	RegisterUnityClass<AudioBehaviour>("Audio");
	//8. AudioClip
	RegisterUnityClass<AudioClip>("Audio");
	//9. AudioListener
	RegisterUnityClass<AudioListener>("Audio");
	//10. AudioManager
	RegisterUnityClass<AudioManager>("Audio");
	//11. AudioResource
	RegisterUnityClass<AudioResource>("Audio");
	//12. SampleClip
	RegisterUnityClass<SampleClip>("Audio");
	//13. Behaviour
	RegisterUnityClass<Behaviour>("Core");
	//14. BuildSettings
	RegisterUnityClass<BuildSettings>("Core");
	//15. Camera
	RegisterUnityClass<Camera>("Core");
	//16. Component
	RegisterUnityClass<Unity::Component>("Core");
	//17. ComputeShader
	RegisterUnityClass<ComputeShader>("Core");
	//18. Cubemap
	RegisterUnityClass<Cubemap>("Core");
	//19. CubemapArray
	RegisterUnityClass<CubemapArray>("Core");
	//20. DelayedCallManager
	RegisterUnityClass<DelayedCallManager>("Core");
	//21. EditorExtension
	RegisterUnityClass<EditorExtension>("Core");
	//22. GameManager
	RegisterUnityClass<GameManager>("Core");
	//23. GameObject
	RegisterUnityClass<GameObject>("Core");
	//24. GlobalGameManager
	RegisterUnityClass<GlobalGameManager>("Core");
	//25. GraphicsSettings
	RegisterUnityClass<GraphicsSettings>("Core");
	//26. InputManager
	RegisterUnityClass<InputManager>("Core");
	//27. LevelGameManager
	RegisterUnityClass<LevelGameManager>("Core");
	//28. Light
	RegisterUnityClass<Light>("Core");
	//29. LightProbes
	RegisterUnityClass<LightProbes>("Core");
	//30. LightingSettings
	RegisterUnityClass<LightingSettings>("Core");
	//31. LightmapSettings
	RegisterUnityClass<LightmapSettings>("Core");
	//32. LowerResBlitTexture
	RegisterUnityClass<LowerResBlitTexture>("Core");
	//33. Material
	RegisterUnityClass<Material>("Core");
	//34. Mesh
	RegisterUnityClass<Mesh>("Core");
	//35. MeshFilter
	RegisterUnityClass<MeshFilter>("Core");
	//36. MeshRenderer
	RegisterUnityClass<MeshRenderer>("Core");
	//37. MonoBehaviour
	RegisterUnityClass<MonoBehaviour>("Core");
	//38. MonoManager
	RegisterUnityClass<MonoManager>("Core");
	//39. MonoScript
	RegisterUnityClass<MonoScript>("Core");
	//40. NamedObject
	RegisterUnityClass<NamedObject>("Core");
	//41. Object
	//Skipping Object
	//42. PlayerSettings
	RegisterUnityClass<PlayerSettings>("Core");
	//43. PreloadData
	RegisterUnityClass<PreloadData>("Core");
	//44. QualitySettings
	RegisterUnityClass<QualitySettings>("Core");
	//45. RectTransform
	RegisterUnityClass<UI::RectTransform>("Core");
	//46. ReflectionProbe
	RegisterUnityClass<ReflectionProbe>("Core");
	//47. RenderSettings
	RegisterUnityClass<RenderSettings>("Core");
	//48. RenderTexture
	RegisterUnityClass<RenderTexture>("Core");
	//49. Renderer
	RegisterUnityClass<Renderer>("Core");
	//50. ResourceManager
	RegisterUnityClass<ResourceManager>("Core");
	//51. RuntimeInitializeOnLoadManager
	RegisterUnityClass<RuntimeInitializeOnLoadManager>("Core");
	//52. Shader
	RegisterUnityClass<Shader>("Core");
	//53. ShaderNameRegistry
	RegisterUnityClass<ShaderNameRegistry>("Core");
	//54. SortingGroup
	RegisterUnityClass<SortingGroup>("Core");
	//55. Sprite
	RegisterUnityClass<Sprite>("Core");
	//56. SpriteAtlas
	RegisterUnityClass<SpriteAtlas>("Core");
	//57. SpriteRenderer
	RegisterUnityClass<SpriteRenderer>("Core");
	//58. TagManager
	RegisterUnityClass<TagManager>("Core");
	//59. TextAsset
	RegisterUnityClass<TextAsset>("Core");
	//60. Texture
	RegisterUnityClass<Texture>("Core");
	//61. Texture2D
	RegisterUnityClass<Texture2D>("Core");
	//62. Texture2DArray
	RegisterUnityClass<Texture2DArray>("Core");
	//63. Texture3D
	RegisterUnityClass<Texture3D>("Core");
	//64. TimeManager
	RegisterUnityClass<TimeManager>("Core");
	//65. Transform
	RegisterUnityClass<Transform>("Core");
	//66. Grid
	RegisterUnityClass<Grid>("Grid");
	//67. GridLayout
	RegisterUnityClass<GridLayout>("Grid");
	//68. Collider
	RegisterUnityClass<Collider>("Physics");
	//69. PhysicsManager
	RegisterUnityClass<PhysicsManager>("Physics");
	//70. Rigidbody
	RegisterUnityClass<Rigidbody>("Physics");
	//71. BoxCollider2D
	RegisterUnityClass<BoxCollider2D>("Physics2D");
	//72. Collider2D
	RegisterUnityClass<Collider2D>("Physics2D");
	//73. CompositeCollider2D
	RegisterUnityClass<CompositeCollider2D>("Physics2D");
	//74. Physics2DSettings
	RegisterUnityClass<Physics2DSettings>("Physics2D");
	//75. Rigidbody2D
	RegisterUnityClass<Rigidbody2D>("Physics2D");
	//76. Font
	RegisterUnityClass<TextRendering::Font>("TextRendering");
	//77. TextMesh
	RegisterUnityClass<TextRenderingPrivate::TextMesh>("TextRendering");
	//78. Tilemap
	RegisterUnityClass<Tilemap>("Tilemap");
	//79. TilemapCollider2D
	RegisterUnityClass<TilemapCollider2D>("Tilemap");
	//80. TilemapRenderer
	RegisterUnityClass<TilemapRenderer>("Tilemap");
	//81. Canvas
	RegisterUnityClass<UI::Canvas>("UI");
	//82. CanvasGroup
	RegisterUnityClass<UI::CanvasGroup>("UI");
	//83. CanvasRenderer
	RegisterUnityClass<UI::CanvasRenderer>("UI");
	//84. UIRenderer
	RegisterUnityClass<UIRenderer>("UIElements");

}
