using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScript : MonoBehaviour
{
    Dictionary<string, Country> countries = new Dictionary<string, Country>();
    Dictionary<string, long> init_country_data = new Dictionary<string, long>();
    List<Dictionary<string, long>> history = new List<Dictionary<string, long>>();

    public Text[] texts;
    public Dictionary<string, int> text_names = new Dictionary<string, int>();
    public Dictionary<string, string> text_descriptions = new Dictionary<string, string>();

   
    public static int turn = 0;

    void Awake()
    {
        text_names.Add("total", 0);
        text_descriptions.Add("total", "総人口");
        text_names.Add("good", 1);
        text_descriptions.Add("good", "健常者");
        text_names.Add("infected", 2);
        text_descriptions.Add("infected", "感染者");
        text_names.Add("deceased", 3);
        text_descriptions.Add("deceased", "死亡者");
        text_names.Add("turn", 4);
        text_descriptions.Add("turn", "ターン");
        text_names.Add("cured",5);
        text_descriptions.Add("cured","回復者");
       
    }

    // Start is called before the first frame update
    void Start()
    {
        init_country_data.Add("日本", 3000);
       
        foreach (KeyValuePair<string, long> country_data in init_country_data) {
            Debug.Log(country_data);
            Country country = new Country();
            country.Initialize(
                country_data.Key,
                country_data.Value
                );
            countries.Add(country.country_name, country);
        }

        ShowText(CalcPopulationData());
    }

    public Dictionary<string, long> CalcPopulationData()
    {
        Dictionary<string, long> result = new Dictionary<string, long>();
        result.Add("total", 0);
        result.Add("good", 0);
        result.Add("infected", 0);
        result.Add("deceased", 0);
        result.Add("cured", 0);
        result.Add("turn", turn);

        foreach (Country country in this.countries.Values)
        {
            Dictionary<string, long> population = country.CalcPopulationData();
            result["total"] += population["total"];
            result["good"] += population["good"];
            result["infected"] += population["infected"];
            result["deceased"] += population["deceased"];
            result["cured"] += population["cured"];
        }

        return result;
    }

    public void GoNextTurn()
    {
        turn++;
        foreach (Country country in this.countries.Values)
        {
            country.GoNextTurn();
        }

        Dictionary<string, long> data = CalcPopulationData();
        history.Add(data);
        this.ShowText(data);
    }

    public void ShowText(Dictionary<string, long> data)
    {
        foreach (KeyValuePair<string, int> i in text_names)
        {
            texts[i.Value].text = text_descriptions[i.Key]
                + ": "
                + data[i.Key].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

