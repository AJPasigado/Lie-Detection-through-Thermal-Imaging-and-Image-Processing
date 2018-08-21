using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using numl;
using numl.Model;
using numl.Supervised;
using numl.Supervised.NaiveBayes;

namespace Lie_Detection {

    class NaiveBayes {
        public IGenerator EBTI_generator = new NaiveBayesGenerator(2);
        public LearningModel EBTI_learned;
        public IModel EBTI_model;

        public double EBTI_GenerateModel()
        {
            EBTI_generator.Descriptor = Descriptor.Create<Slopes>();
            Slopes[] sl = {
                new Slopes() { thermalSlope = 1.0, eyesSlope = 2.6, result = true } ,
                new Slopes() { thermalSlope = 1.0, eyesSlope = 1.0, result = false } ,
                new Slopes() { thermalSlope = 1.0, eyesSlope = 0.7, result = false } ,
                new Slopes() { thermalSlope = 1.0, eyesSlope = 2.7, result = true } ,
                new Slopes() { thermalSlope = 1.0, eyesSlope = 1.5, result = false } ,
                new Slopes() { thermalSlope = 1.0, eyesSlope = 1.7, result = true } ,
                new Slopes() { thermalSlope = 1.0, eyesSlope = 1.3, result = false } ,
                new Slopes() { thermalSlope = 1.0, eyesSlope = 1.9, result = true }
            };
            EBTI_learned = Learner.Learn(sl, 1, 1000, EBTI_generator);
            EBTI_model = EBTI_learned.Model;
            return EBTI_learned.Accuracy;
        }

        public bool EBTI_Predict(double thermalSlope, double eyesSlope)
        {
            return EBTI_model.Predict(new Slopes() { thermalSlope = thermalSlope, eyesSlope = eyesSlope }).result;
        }







        public IGenerator EB_generator = new NaiveBayesGenerator(2);
        public LearningModel EB_learned;
        public IModel EB_model;

        public double EB_GenerateModel()
        {
            EB_generator.Descriptor = Descriptor.Create<Slopes>();

            var reader = Properties.Resources.EB_TrainingSet;
            List<Slopes> listSlope = new List<Slopes>();

            using (StringReader lines = new StringReader(reader))
            {
                string line;
                while ((line = lines.ReadLine()) != null)
                {
                    var values = line.Split(',');
                    listSlope.Add(new Slopes() { thermalSlope = 0, eyesSlope = Double.Parse(values[0]), result = Boolean.Parse(values[1]) });
                }
            }

            Slopes[] sl = listSlope.ToArray();

            EB_learned = Learner.Learn(sl, 0.8, 1000, EB_generator);
            EB_model = EB_learned.Model;
            
            return EB_learned.Accuracy;
        }

        public bool EB_Predict(double slope)
        {
            return EB_model.Predict(new Slopes() { thermalSlope = 0, eyesSlope = slope }).result;
        }










        public IGenerator TI_generator = new NaiveBayesGenerator(2);
        public LearningModel TI_learned;
        public IModel TI_model;

        public double TI_GenerateModel()
        {
            TI_generator.Descriptor = Descriptor.Create<Slopes>();
            Slopes[] sl = {
                new Slopes() { thermalSlope = 2.6, result = true } ,
                new Slopes() { thermalSlope = 1.0, result = false } ,
                new Slopes() { thermalSlope = 0.7, result = false } ,
                new Slopes() { thermalSlope = 2.7, result = true } ,
                new Slopes() { thermalSlope = 1.5, result = false } ,
                new Slopes() { thermalSlope = 1.7, result = true } ,
                new Slopes() { thermalSlope = 1.3, result = false } ,
                new Slopes() { thermalSlope = 1.9, result = true }
            };
            TI_learned = Learner.Learn(sl, 0.8, 1000, TI_generator);
            TI_model = EB_learned.Model;
            return TI_learned.Accuracy;
        }

        public bool TI_Predict(double slope)
        {
            return TI_model.Predict(new Slopes() { thermalSlope = slope }).result;
        }


    }

    public class Slopes
    {
        [Feature]
        public double thermalSlope { get; set; }

        [Feature]
        public double eyesSlope { get; set; }

        [Label]
        public bool result { get; set; }
    }
}
