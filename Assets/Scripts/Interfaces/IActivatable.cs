using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivatable
{
    bool Activated {get;}
    void Activate();
    void Deactivate();
}
