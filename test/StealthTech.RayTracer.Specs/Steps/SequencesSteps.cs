//-----------------------------------------------------------------------
// <copyright file="SequencesSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class SequencesSteps
    {
        private readonly SequencesContext _sequencesContext;

        public SequencesSteps(SequencesContext sequencesContext)
        {
            _sequencesContext = sequencesContext;
        }

        [Given(@"generator ← Sequence\((.*), (.*), (.*)\)")]
        public void GivenGeneratorSequence(double n1, double n2, double n3)
        {
            _sequencesContext.Sequences = new DeterministicSequence(n1, n2, n3);
        }

        [Then(@"generator\.Next\(\) = (.*)")]
        public void ThenNextGenerator(double expectedValue)
        {
            Assert.Equal(expectedValue, _sequencesContext.Sequences.Next());
        }
    }
}
