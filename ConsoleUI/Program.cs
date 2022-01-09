// See https://aka.ms/new-console-template for more information

using Business.Abstract;
using Business.DependencyResolvers.Ninject;

IDifficultyService _difficultyService = InstanceFactory.GetInstance<IDifficultyService>();

var difficulties = _difficultyService.GetAll();
