# Per Kringelbach - Flow 2  Handin

## Projektbeskrivelse
I det andet unity-project har vi i vores gruppe valgt at lavet et Tower Defence spil med et middelalder tema. Selve spillet går ud på at forsvare borgen med kanoner overfor en hær af riddere. Før spillet starter sætter man et given antal kanontårne på borgmuren strategisk, hvorefter man starter selve angrebet. Det gælder om at slå alle de angribende riddere ihjel inden de når igennem banen. 
 
Vi valgte at fordele opgaverne og bruge Trello samt Git til projektstyring.

Min opgave var at lave en NPC(er) (Prefab) med AI mechanics og animation. Den anden opgave var at få NPC(er) til at følge en given sti ved hjælp af NavMesh. 
## NavMesh, Prefabs & animation
Jeg startede med at finde en PreFab NPC 'ridder', som skulle være vores enemy på mixamo.com som jeg downloadede med en løbe animation. Animationen satte jeg på `Entry` i 'Animator' og på `Loop Time` og `Loop Pose` på selve animationens-objectet, så han løber på stedet.
Jeg hentede også NavMeshComponent package fra Unity, som gør det nemt at lave NavMesh. Man starter med at lave et tomt GameObject og tilføjer et Component 'NavMeshSurface' hvorefter man trykker `Bake`. Bagefter vælger man de objecter der skal enten være Walkable eller Not Walkable ved brug af 'NavMeshModifier' Component. Herefter trykker man `bake` igen. På NavMesh kan man vælge hvilen `Agent Type` og for eksempel vinklen som vore NPC'er kan gå på.


## Components & Scripting

### Follow Parth
For at få vores NPC'er til at følge en bestemt rute lavede jeg et script som tager et array af points så man kan tilføje et given antal destinations objecter som vores NPC'er kan følge. Når NPC'erne når det sidste object søger de tilbage til det første object.
### Destroy NPC
Hvis vore NPC(er) når til enden af level bliver de Destroyed med et script som kigger efter Tag 'Enemy' og er sat på et GameObject med Box Collider som `Is Trigger`.