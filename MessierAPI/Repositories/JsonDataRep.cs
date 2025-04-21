using MessierAPI.Models;
using Newtonsoft.Json;
using MessierAPI.Exceptions;

namespace MessierAPI.Repositories;
public interface IJsonDataRep
{
	List<MessierModel> GetMessierObjects(string? tipo = null);
	List<PlanetsModel> GetPlanets(string? tipo = null);
	List<BlackHoleModel> GetBlackholeObjects(string? tipo = null);
}

public class JsonDataRep : IJsonDataRep
{
	public List<MessierModel> GetMessierObjects(string? tipo)
	{
		try
		{
			string JsonData = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Messier.json");
			List<MessierModel> messier = JsonConvert.DeserializeObject<List<MessierModel>>(System.IO.File.ReadAllText(JsonData)) ?? throw new DataNotFoundException("No se encontraron datos.");

			if (!string.IsNullOrEmpty(tipo)) messier = messier.Where(Messi => Messi.Tipo.ToLower() == tipo.ToLower()).ToList();

			return messier;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error loading Messier objects: {ex.Message}");
			return new List<MessierModel>();
		}
	}

	public List<PlanetsModel> GetPlanets(string? tipo)
	{
		try
		{
			string JsonData = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Planets.json");
			List<PlanetsModel> planets = JsonConvert.DeserializeObject<List<PlanetsModel>>(System.IO.File.ReadAllText(JsonData)) ?? throw new DataNotFoundException("No se encontraron datos.");

			if (!string.IsNullOrEmpty(tipo)) planets = planets.Where(pla => pla.Tipo.ToLower() == tipo.ToLower()).ToList();

			return planets;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error loading planets: {ex.Message}");
			return new List<PlanetsModel>();
		}
	}

	public List<BlackHoleModel> GetBlackholeObjects(string? tipo)
	{
		try
		{
			string JsonData = Path.Combine(Directory.GetCurrentDirectory(), "Data", "BlackHole.json");
			List<BlackHoleModel> BlackHoles = JsonConvert.DeserializeObject<List<BlackHoleModel>>(System.IO.File.ReadAllText(JsonData)) ?? throw new DataNotFoundException("No se encontraron datos.");

			if (!string.IsNullOrEmpty(tipo)) BlackHoles = BlackHoles.Where(bh => bh.Tipo.ToLower() == tipo.ToLower()).ToList();

			return BlackHoles;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error loading black holes: {ex.Message}");
			return new List<BlackHoleModel>();
		}
	}
}


