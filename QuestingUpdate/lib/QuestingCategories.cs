using UnityEngine;

namespace VolcQuestingUpdate.lib
{
    class QuestingCategories : MonoBehaviour
    {
        public void InitCategories()
        {
            CreateRecipeCategory("ForgeTier1", "DF5145974CB54D7F972367F70CA75099");
            CreateRecipeCategory("ForgeTier2", "EF4888B484944B4DB20B100FE3ED4760");
            CreateRecipeCategory("ForgeTier3", "52BACA27F2744A11AC5A8FDDFD393426");
            CreateFactoryCategory("AlloyForge", "293AC5131E4D4ED5948FA4482CAD10B6");
            CreateModuleCategory("AlloyForge", "EAB2EA1154F34FFF8CC74CA0C23ECACD");

            Debug.Log("[Questing Update | Categories]: Categories Loaded...");
        }

        private void CreateFactoryCategory(string name, string categoryId)
        {
            var ok = ScriptableObject.CreateInstance<FactoryType>();
            ok.name = name;
            var guid = GUID.Parse(categoryId);
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = ok, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }

        private void CreateModuleCategory(string name, string categoryId)
        {
            var ok = ScriptableObject.CreateInstance<ModuleCategory>();
            ok.name = name;
            var guid = GUID.Parse(categoryId);
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = ok, Guid = guid, Labels = new string[4] } };
            RuntimeAssetStorage.Add(assets, default);
        }

        private void CreateRecipeCategory(string name, string categoryId)
        {
            var Forge = ScriptableObject.CreateInstance<RecipeCategory>();
            Forge.name = name;
            var guid = GUID.Parse(categoryId);
            AssetReference[] assets = new AssetReference[] { new AssetReference() { Object = Forge, Guid = guid, Labels = new string[0] } };
            RuntimeAssetStorage.Add(assets, default);
        }
    }
}
