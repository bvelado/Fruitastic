using System;
using Entitas;
using UnityEngine;

public class GrowingSlotsView : MonoBehaviour, IGrowingEntityChangedListener, IProducingEntityChangedListener, IPlantedEntityChangedListener {

    [SerializeField]
    private EGrowableType GrowableType;
    [SerializeField]
    private GrowingSlotView[] Slots;
    [SerializeField]
    private GrowingInfoPanelView InfoPanelView;

    private IGroup<GameEntity> _plantedEntities;

    private UIEntity e;

    private bool initialized = false;

    private void Start()
    {        
        for(int i = 0; i < Slots.Length; i++)
        {
            var slotEntity = Contexts.sharedInstance.game.CreateEntity();
            if (GrowableType == EGrowableType.Fruit)
            {
                slotEntity.AddFruitSlot(i);
            } else
            {
                slotEntity.AddVegetableSlot(i);
            }
        }
    } 

    private void OnEnable()
    {
        if(GrowableType == EGrowableType.Fruit)
            _plantedEntities = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Fruit, GameMatcher.Planted));
        else if(GrowableType == EGrowableType.Vegetable)
            _plantedEntities = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Vegetable, GameMatcher.Planted));

        e = Contexts.sharedInstance.uI.CreateEntity();
        e.AddGrowingEntityChanged(this);

        if(GrowableType == EGrowableType.Fruit)
            e.AddProducingEntityChanged(this);
    }

    private void OnDisable()
    {
        if (e.isEnabled && e.hasGrowingEntityChanged)
            e.Destroy();
    }

    private void UpdateView(GameEntity entity)
    {
        if (!entity.isFruit && GrowableType == EGrowableType.Fruit)
            return;

        if (!entity.isVegetable && GrowableType == EGrowableType.Vegetable)
            return;

        if (entity.planted.SlotIndex < Slots.Length)
        {
            if (entity.hasIcon)
                Slots[entity.planted.SlotIndex].Icon.sprite = entity.icon.Sprite;

            if (entity.hasGrowing)
            {
                Slots[entity.planted.SlotIndex].GrowthProgress.fillAmount = (entity.growing.Elapsed * 1.0f) / (entity.growable.Duration * 1.0f);
            } else if (entity.hasProducing)
            {
                Slots[entity.planted.SlotIndex].ProductionProgress.fillAmount = (entity.producing.Elapsed * 1.0f) / (entity.productor.Frequency * 1.0f);
            }
            else
            {
                Slots[entity.planted.SlotIndex].GrowthProgress.fillAmount = 0f;
            }
        }

        InfoPanelView.Display(entity);
    }

    private void ClearSlot(int index)
    {
        Slots[index].Icon.sprite = null;
        Slots[index].GrowthProgress.fillAmount = 0f;
        Slots[index].ProductionProgress.fillAmount = 0f;
    }

    public void GrowingEntityChanged(GameEntity entity)
    {
        if (entity.hasGrowing)
            UpdateView(entity);
    }

    public void ProducingEntityChanged(GameEntity entity)
    {
        if (entity.hasProducing)
            UpdateView(entity);
    }

    public void PlantedEntityChanged(GameEntity entity)
    {
        if(!entity.hasPlanted)
        {
            for(int i = 0; i < GameParametersManager.Instance.Parameters.MAX_FRUIT_SLOTS; i++)
            {
                var fruitEntity = Contexts.sharedInstance.game.GetFruitEntityBySlotIndex(i);
                if (fruitEntity == null)
                {
                    ClearSlot(i);
                }
            }
        }
    }
}
