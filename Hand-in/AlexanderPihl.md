# Alexander Pihl - Flow 2 Handin
Vi har samlet i gruppen valgt at lave et Tower Defence spil som tager udgangspunkt i et medieval tema. Derfor har indtil videre designet et level med dertilhørende fjender, kanon tårne, UI osv.

I dette projekt har jeg stået for alt UI i spillet og spawning af nye cannon towers. 

# Emner brugt:

### - Scripts og references.
  - Der er brugt scripts til at styre de forskellige UI knapper såsom, start(play), restart game, volume slider osv.
  - Der er også brugt script til spawning af nye cannon towers.
### - Camera
  - Til vinkling af view så hele banen med tilkoblet UI kan ses.
### - UI elementer
  - Canvas
    - Til at indramme UI både ind-game og i startmenu.
  - Image
    - Til styling og farver.
  - Panel
    - Til styling og farver.
  - Slider
    - Til visuel styring af volumen fra kanoneksplotionerne in-game.
  - Eventsystem
    - Til håndtering af events.
### - AudioMixer (til håndtering af volume slider)
  - Sat sammen med cannonSound og script for at håndtere lyd volume
### - Build settings
  - I form at scene queue til styren af load af level fra startmenu
### - Parenting & Childs

