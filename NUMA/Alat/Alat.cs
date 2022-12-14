using Godot;
using System;

/// <summary> Objekat Alata. </summary>
public class Alat : Spatial {
    
    private float _brzinaHoda = 0;
    /// <summary> Brzina kojom će se alat kretati u sekundama. </summary>
    public float BrzinaHoda {
        get => _brzinaHoda;
        set {
            if (value >= 0) {
                _brzinaHoda = value;
            } else {
                throw new ArgumentException($"Očekivana brzina hoda alata veća od 0, a dobijena { value }.");
            }
        }
    }

    /// <summary> Pozicija do koje alat treba da stigne. </summary>
    private Vector3 ?CiljnaPozicija;


    public override void _PhysicsProcess(float delta) {
        base._PhysicsProcess(delta);

        if (CiljnaPozicija == null) return;

        if (Translation == CiljnaPozicija) {
            CiljnaPozicija = null;
            return;
        }

        float moveAmount = BrzinaHoda * delta;
        Translation = Translation.MoveToward((Vector3)CiljnaPozicija, moveAmount);
    }


    /// <summary> Pomera alat određenom brzinom na novu poziciju u koord. sistemu mašine. </summary>
    public void Pomeri(Vector3 gde, float brzina) {
        BrzinaHoda = brzina;
        CiljnaPozicija = gde;
        
    }

}
