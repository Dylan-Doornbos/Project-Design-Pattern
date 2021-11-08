using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager instance;
    
    public bool isRewinding { get; private set; } = false;
    private Stack<commandTime> _commandTimes = new Stack<commandTime>();
    public float timeStamp { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (!isRewinding)
        {
            timeStamp += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(rewind());
            }
        }
    }

    private IEnumerator rewind()
    {
        isRewinding = true;
        
        while (Input.GetKey(KeyCode.R) && timeStamp > 0)
        {
            timeStamp -= Time.deltaTime; //Rewind the timestamp

            //Undo every command that happened after the current timestamp
            while (_commandTimes.Count > 0 && _commandTimes.Peek()._timeStamp > timeStamp)
            {
                _commandTimes.Pop()._command.Undo();
            }

            yield return null;
        }
        
        isRewinding = false;
        
        yield return null;
    }

    public void AddCommand(Command command)
    {
        commandTime commandTime = new commandTime(command, timeStamp);
        _commandTimes.Push(commandTime);
    }
}

struct commandTime
{
    public Command _command;
    public float _timeStamp;

    public commandTime(Command command, float timeStamp)
    {
        _command = command;
        _timeStamp = timeStamp;
    }
}