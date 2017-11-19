using System;
using Entitas;
using UnityEngine;

public class FruitSlotsView : MonoBehaviour, ITickChangedListener, IGrowingEntityChangedListener, IProducingEntityChangedListener {

    [SerializeField]
    private FruitSlotView[] Slots;

    private IGroup<GameEntity> _plantedFruits;

    private UIEntity e;

    private bool initialized = false;

    private void Start()
    {
        for(int i = 0; i < Slots.Length; i++)
        {
            var fruitSlotEntity = Contexts.sharedInstance.game.CreateEntity();
            fruitSlotEntity.AddFruitSlot(i);
        }
    } 

    private void OnEnable()
    {
        _plantedFruits = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Fruit, GameMatcher.Planted));

        e = Contexts.sharedInstance.uI.CreateEntity();
        e.AddTickChanged(this);
        e.AddGrowingEntityChanged(this);
        e.AddProducingEntityChanged(this);
    }

    private void OnDisable()
    {
        if (e.isEnabled && e.hasTickChanged && e.hasPlantedEntityChanged)
            e.Destroy();
    }

    private void UpdateView(GameEntity entity)
    {
        if(entity.planted.SlotIndex < Slots.Length)
        {
            if(entity.hasGrowing)
            {
                Slots[entity.planted.SlotIndex].GrowthProgress.fillAmount = (entity.growing.Elapsed * 1.0f) / (entity.fruit.FruitData.GrowthDuration * 1.0f);
            } else
            {
                Slots[entity.planted.SlotIndex].GrowthProgress.fillAmount = 0f;
            }
            if (entity.hasProducing)
            {
                Slots[entity.planted.SlotIndex].ProductionProgress.fillAmount = (entity.producing.Elapsed * 1.0f) / (entity.fruit.FruitData.Frequency * 1.0f);
            }
        }
    }

    public void TickChanged(long value)
    {
        //Debug.Log("tick");
        //foreach(var plantedFruit in _plantedFruits.GetEntities())
        //{
            
        //    UpdateView(plantedFruit.planted.SlotIndex, value);
        //}        
    }

    public void GrowingEntityChanged(GameEntity entity)
    {
        if (entity.hasFruit)
            UpdateView(entity);
    }

    public void ProducingEntityChanged(GameEntity entity)
    {
        if (entity.hasFruit)
            UpdateView(entity);
    }
}
