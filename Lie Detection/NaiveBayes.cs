using System;
using numl;
using numl.Model;
using numl.Supervised;
using numl.Supervised.NaiveBayes;

namespace Lie_Detection {

    class NaiveBayes {
        public IGenerator generator = new NaiveBayesGenerator(2);
        public LearningModel learned;
        public IModel model;

        public double GenerateModel() {
            generator.Descriptor = Descriptor.Create<Slopes>();
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
            learned = Learner.Learn(sl, 0.8, 1000, generator);
            model = learned.Model;
            return learned.Accuracy;
        }

        public bool Predict(double thermalSlope, double eyesSlope) {
            return model.Predict(new Slopes() { thermalSlope = thermalSlope, eyesSlope = eyesSlope}).result;
        }
    }

    public class Slopes {
        [Feature]
        public double thermalSlope { get; set; }

        [Feature]
        public double eyesSlope { get; set; }

        [Label]
        public bool result { get; set; }
    }
}
