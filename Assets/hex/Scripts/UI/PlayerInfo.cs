﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private MovesManager movesManager = null;

    [SerializeField] private Image backgroundImage = null;
    [SerializeField] private Text label = null;

    private void Awake()
    {
        movesManager = FindObjectOfType<MovesManager>();
    }

    private void OnEnable()
    {
        movesManager.OnMoveEnd += OnMoveEnd;
    }

    private void OnDisable()
    {
        movesManager.OnMoveEnd -= OnMoveEnd;
    }

    private void OnMoveEnd(Player player, bool isFirstStage)
    {
        string t = isFirstStage ? "Фаза атаки" : "Фаза пополнения";
        string t1 = isFirstStage ? string.Empty : $"Войск в наличии - {player.AvailableAmount}";
        label.text = $"{t} - сейчас ходит {player.Name} {t1}";

        backgroundImage.color = player.Color;
    }
}
