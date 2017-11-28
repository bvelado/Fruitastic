using Entitas;
using System.Collections.Generic;
using System;

public class HandlePlantSelectedEntityInputSystem : ReactiveSystem<InputEntity>
{
    Contexts _contexts;
    IGroup<GameEntity> _plantedFruits;
    IGroup<GameEntity> _plantedVegetables;

    public HandlePlantSelectedEntityInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
        _plantedFruits = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Fruit, GameMatcher.Planted));
        _plantedVegetables = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Vegetable, GameMatcher.Planted));
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach(var e in entities)
        {
            if(_contexts.game.isSelected && _contexts.game.selectedEntity.isStored && !_contexts.game.selectedEntity.hasPlanted)
            {
                if (_contexts.game.selectedEntity.isFruit)
                {
                    if(_plantedFruits.count < GameParametersManager.Instance.Parameters.MAX_FRUIT_SLOTS)
                    {
                        List<int> takenIndexes = new List<int>();
                        foreach(var plantedFruit in _plantedFruits)
                        {
                            takenIndexes.Add(plantedFruit.planted.SlotIndex);
                        }
                        
                        for(int i = 0; i < GameParametersManager.Instance.Parameters.MAX_FRUIT_SLOTS; i++)
                        {
                            if (!takenIndexes.Contains(i))
                            {
                                // DO PLANT
                                _contexts.game.selectedEntity.isStored = false;

                                if(!_contexts.game.selectedEntity.hasPlanted)
                                    _contexts.game.selectedEntity.AddPlanted(i);

                                if (!_contexts.game.selectedEntity.hasGrowing)
                                    _contexts.game.selectedEntity.AddGrowing(0);
                            }
                        }
                    }
                }

                if (_contexts.game.selectedEntity.isVegetable)
                {
                    if (_plantedVegetables.count < GameParametersManager.Instance.Parameters.MAX_VEGETABLES_SLOTS)
                    {
                        List<int> takenIndexes = new List<int>();
                        foreach (var plantedVegetable in _plantedVegetables)
                        {
                            takenIndexes.Add(plantedVegetable.planted.SlotIndex);
                        }

                        for (int i = 0; i < GameParametersManager.Instance.Parameters.MAX_VEGETABLES_SLOTS; i++)
                        {
                            if (!takenIndexes.Contains(i))
                            {
                                // DO PLANT
                                _contexts.game.selectedEntity.isStored = false;

                                if (!_contexts.game.selectedEntity.hasPlanted)
                                    _contexts.game.selectedEntity.AddPlanted(i);
                            }
                        }
                    }
                }
            }
            e.Destroy();
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        if (entity.hasPlantSelectedEntity)
            return true;
        return false;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.PlantSelectedEntity);
    }
}
