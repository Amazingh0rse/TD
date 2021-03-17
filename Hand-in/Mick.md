# Mick Larsen - Flow 2 Handin

Vi har samlet i gruppen valgt at lave et Tower Defence spil som tager udgangspunkt i et medieval tema. Derfor har indtil videre designet et level med dertilhørende fjender, kanon tårne, UI osv.

I dette projekt har jeg stået for tårnet med "Shooting & mechanics".

## Emner brugt:

- Prefabs + parenting
- Animations, Animator & IK
- Game Mechanics and Features

![Imgur](https://imgur.com/a/jykuzN3.gif)

Jeg har anvendt prefabs til tårnet som har flere script components til at håndtere "Animation"/transform af kanonen på
toppen af tårnet.

## Udvalgte features

### Target based rotation

Når gameobjects med tag "Enemy" kommer indenfor tårnets trigger, registreres de, kanonen sigter efter en enemy og affyrer skud.
Rotationen ligger i `Update()` og er lavet således:

```C#
//Get the direction to the target
Vector3 direction = target.transform.position - transform.position;
//Determine the rotation towards the target
Quaternion lookRotation = Quaternion.LookRotation(direction);
//Prepare the direction and speed for rotation
Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
//Rotate the model
partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
```

Lerp (Linear interpolation) sørger for en glidende bevægelse i rotationen.

### Gizmo

Som udvikler kan det være rart med visuelle værktøjer - derfor har jeg anvendt `OnDrawGizmoSelected()` til at visualisere tårnets rækkevidde i editoren.

```c#
public float range = 20f;

private void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, range);
}
```
Det ser sådan ud i editoren (Røde gizmo)
![Imgur](https://imgur.com/rlbihS8.png)

### Canonball targeting
Når tårnet registrerer en enemy instantieres en canonball som sendes imod target. Oprindeligt havde jeg problemer med, at kuglen "Fulgte efter" en enemy, men fik opdateret scriptet så den sendes i mod en fast position, som enemy har været på.

Det script ser således ud: 

``` c#
void FixedUpdate()
{
//Check if target exists
    if (target != null){
        //Fly towards target
        Vector3 direction = target - transform.position;
        GetComponent<Rigidbody>().velocity = direction.normalized * speed;
        Destroy(gameObject, 5f);
    }
    else{
        //if target is gone, destroy self
        Destroy(gameObject);
    }
}
```

Her er target registreret som et public gameobject der sættes i canonball prefab'en.
