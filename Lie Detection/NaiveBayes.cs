using System;
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
            EBTI_generator.Descriptor = Descriptor.Create<EBTI_Slopes>();
            EBTI_Slopes[] sl = {
                new EBTI_Slopes() { thermalSlope = 1.0, eyesSlope = 2.6, result = true } ,
                new EBTI_Slopes() { thermalSlope = 1.0, eyesSlope = 1.0, result = false } ,
                new EBTI_Slopes() { thermalSlope = 1.0, eyesSlope = 0.7, result = false } ,
                new EBTI_Slopes() { thermalSlope = 1.0, eyesSlope = 2.7, result = true } ,
                new EBTI_Slopes() { thermalSlope = 1.0, eyesSlope = 1.5, result = false } ,
                new EBTI_Slopes() { thermalSlope = 1.0, eyesSlope = 1.7, result = true } ,
                new EBTI_Slopes() { thermalSlope = 1.0, eyesSlope = 1.3, result = false } ,
                new EBTI_Slopes() { thermalSlope = 1.0, eyesSlope = 1.9, result = true }
            };
            EBTI_learned = Learner.Learn(sl, 0.8, 1000, EBTI_generator);
            EBTI_model = EBTI_learned.Model;
            return EBTI_learned.Accuracy;
        }

        public bool EBTI_Predict(double thermalSlope, double eyesSlope)
        {
            return EBTI_model.Predict(new EBTI_Slopes() { thermalSlope = thermalSlope, eyesSlope = eyesSlope }).result;
        }







        public IGenerator EB_generator = new NaiveBayesGenerator(1);
        public LearningModel EB_learned;
        public IModel EB_model;

        public double EB_GenerateModel()
        {
            EB_generator.Descriptor = Descriptor.Create<EBTI_Slopes>();
            Slopes[] sl = {
                new Slopes() { slope = 2.6, result = true } ,
                new Slopes() { slope = 1.0, result = false } ,
                new Slopes() { slope = 0.7, result = false } ,
                new Slopes() { slope = 2.7, result = true } ,
                new Slopes() { slope = 1.5, result = false } ,
                new Slopes() { slope = 1.7, result = true } ,
                new Slopes() { slope = 1.3, result = false } ,
                new Slopes() { slope = 1.9, result = true }
            };
            EB_learned = Learner.Learn(sl, 0.8, 1000, EB_generator);
            EB_model = EB_learned.Model;
            return EB_learned.Accuracy;
        }

        public bool EB_Predict(double slope)
        {
            return EB_model.Predict(new Slopes() { slope = slope }).result;
        }










        public IGenerator TI_generator = new NaiveBayesGenerator(1);
        public LearningModel TI_learned;
        public IModel TI_model;

        public double TI_GenerateModel()
        {
            TI_generator.Descriptor = Descriptor.Create<EBTI_Slopes>();
            Slopes[] sl = {
                new Slopes() { slope = 2.6, result = true } ,
                new Slopes() { slope = 1.0, result = false } ,
                new Slopes() { slope = 0.7, result = false } ,
                new Slopes() { slope = 2.7, result = true } ,
                new Slopes() { slope = 1.5, result = false } ,
                new Slopes() { slope = 1.7, result = true } ,
                new Slopes() { slope = 1.3, result = false } ,
                new Slopes() { slope = 1.9, result = true }
            };
            TI_learned = Learner.Learn(sl, 0.8, 1000, TI_generator);
            TI_model = EB_learned.Model;
            return TI_learned.Accuracy;
        }

        public bool TI_Predict(double slope)
        {
            return TI_model.Predict(new Slopes() { slope = slope }).result;
        }


    }

    public class EBTI_Slopes
    {
        [Feature]
        public double thermalSlope { get; set; }

        [Feature]
        public double eyesSlope { get; set; }

        [Label]
        public bool result { get; set; }
    }

    public class Slopes
    {
        [Feature]
        public double slope { get; set; }

        [Label]
        public bool result { get; set; }
    }
}
