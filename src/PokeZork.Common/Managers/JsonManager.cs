using PokeZork.Common.Managers.JsonModels;
using System.Text;
using System.Text.Json;

namespace PokeZork.Common.Managers
{
    public class JsonManager
    {
        private readonly string _dataPath;
        private readonly JsonSerializerOptions _jsonOptions;
        public JsonManager(string dataPath, JsonSerializerOptions options = null)
        {
            this._dataPath = dataPath;
            if(options != null)
            {
                this._jsonOptions = options;
            }
            else
            {
                this._jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    AllowTrailingCommas = true,
                };
            }
        }

        public Campaign LoadCampaignFromJson()
        {
            if (string.IsNullOrWhiteSpace(this._dataPath))
                throw new ArgumentException("Data path is not set.", nameof(_dataPath));

            if (!File.Exists(this._dataPath))
                throw new FileNotFoundException("Campaign JSON file not found.", this._dataPath);

            string json;
            try
            {
                // Read entire file as UTF-8 text
                json = File.ReadAllText(this._dataPath, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to read campaign JSON file '{this._dataPath}'.", ex);
            }

            try
            {
                var campaign = JsonSerializer.Deserialize<Campaign>(json, this._jsonOptions);
                if (campaign == null)
                    throw new InvalidDataException("Deserialized campaign is null.");

                return campaign;
            }
            catch (JsonException ex)
            {
                throw new InvalidDataException("Failed to deserialize campaign JSON.", ex);
            }
        }

        public bool AddChapterToCampaign(Campaign campaign, Chapter newChapter)
        {
            if (campaign == null)
                throw new ArgumentNullException(nameof(campaign), "Campaign cannot be null.");
            if (newChapter == null)
                throw new ArgumentNullException(nameof(newChapter), "New chapter cannot be null.");
            campaign.Chapters.Add(newChapter);
            return true;
        }

        public bool SaveCampaignToJson(Campaign campaign)
        {
            if (campaign == null)
                throw new ArgumentNullException(nameof(campaign), "Campaign cannot be null.");
            string json;
            try
            {
                json = JsonSerializer.Serialize(campaign, this._jsonOptions);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to serialize campaign to JSON.", ex);
            }
            try
            {
                File.WriteAllText(this._dataPath, json, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to write campaign JSON to file '{this._dataPath}'.", ex);
            }
        }


    }
}
