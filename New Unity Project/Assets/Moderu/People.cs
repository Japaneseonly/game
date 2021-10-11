using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People
{
    public bool infected = false;
    public bool cured = false;
    public bool deceased = false;

    bool ProbabilityCheck(double probability)
    {
        return (Random.value <= probability);
    }

    public void UpdateStatus(Dictionary<string, double> ratio)
    {
        if (!IsInfected())
        {
            infected = ProbabilityCheck(ratio["infect"]);
        }

        if (CanDeceased())
        {
            this.deceased = ProbabilityCheck(ratio["death"]);
        }

        if (this.infected && !this.cured)
        {
            this.cured = ProbabilityCheck(ratio["cure"]);
        }
    }

    /**
     * 感染者かどうか
     */
    public bool IsInfected()
    {
        return infected && !cured;
    }

    /**
     * 発症しているかどうか
     */
    public bool IsDeceasd()
    {
        return infected && deceased && !cured;
    }

    /**
     * 発症可能性があるかどうか
     */
    public bool CanDeceased()
    {
        return infected && !deceased && !cured;
    }
}

