using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country
{
    public string country_name;
    public People[] peoples;
    public long total;
    public List<Dictionary<string, long>> history = new List<Dictionary<string, long>>();

    public void Initialize(string name, long total)
    {
        this.country_name = name;
        this.total = total;
        this.peoples = new People[total];

        for (long i = 0; i < total; i++)
        {
            this.peoples[i] = new People();
        }
        this.peoples[0].infected = true;
    }

    public Dictionary<string, long> CalcPopulationData()
    {
        Dictionary<string, long> result = new Dictionary<string, long>();
        long infected = 0;
        long deceased= 0;
        long cured = 0;

        foreach (People people in peoples)
        {
            if (people.IsInfected()) { infected++; }
            if (people.IsDeceasd()) { deceased++; }
            if (people.cured) { cured++; }
        }

        result.Add("total", this.total - deceased);
        result.Add("good", this.total - infected - cured);
        result.Add("infected", infected);
        result.Add("deceased", deceased);
        result.Add("cured", cured);

        return result;
    }

    public Dictionary<string, double> CalcProbability()
    {
        Dictionary<string, double> probability = new Dictionary<string, double>();
        Dictionary<string, long> count = this.CalcPopulationData();

        // long同士の割り算は小数点以下が切り捨てられるため、double型に直す
        Dictionary<string, double> fixed_count = new Dictionary<string, double>();
        foreach (KeyValuePair<string, long> i in count)
        {
            fixed_count.Add(i.Key, (double)i.Value);
        }

        double ratio_deceased_population =
            fixed_count["infected"] / fixed_count["good"];
       
        probability.Add("infect", 0.2);
        probability.Add("death", 0.06);
        probability.Add("cure", 0.04);

        return probability;
    }

    public void GoNextTurn()
    {
        Debug.Log("goNextTurn");
        Dictionary<string, double> probability = this.CalcProbability();
        foreach (People people in this.peoples)
        {
            people.UpdateStatus(probability);
        }

        history.Add(CalcPopulationData());
    }
}