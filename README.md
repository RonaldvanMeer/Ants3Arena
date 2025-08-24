# Ants3Arena

Active Ants Assessment

Voeg een witte mier toe die anders beweegt dan alle andere mieren en zorg ervoor dat de kwaliteit van de toevoeging productiewaardig is.

Voor alle duidelijkheid: dit gaat geen psychologische test worden. We willen alleen je niveau, denkwijze en manier van communiceren bepalen. En we weten dat dit best wel stressvol kan zijn, zeker op het moment dat je op een groot scherm jouw eigen code moet toelichten en gevraagd wordt om te reageren op vragen. Probeer het te zien als waar het voor bedoeld is: een code review en presentatie van ideeën. Er zijn geen “beste” antwoorden.

## Discussion points

### First Iteration improvements

//BlackAnt = new AntBlack(this.ClientSize); // 1143*750 -> not the size set on the form, possible due to auto resize to fullscreen (from 800*450)
//BlackAnt2 = new AntBlack(this.ClientSize);
//BlackAnt3 = new AntBlack(this.ClientSize);

there for in program.cs setting of the size to 800*450

### Adding white ant

Production ready -> Not breaking production
The existing Black, Red and Yellow ants do overlap on screen.
Introducing a white ant with the same allowence would not break production.

#### Thinking further

BUT if the ants represent actual machine, the machines would collide into each other.
Therefor the begin project already contained a bug (allowing ants to crash/walk over another).
I would introduce a collisionwatcher or some sort, and take evasive actions if the next move would indicate a crash or collision.

Perhaps more context about the assignment would help, describing the entities and what they represent.
Define production ready.

### Future modifications

- Ants can be configured by using configuration settings, Velocity, Direction and Color.
- Extract Movement from Ant class, put the movement in a separate class/service, which can be modified & tested more easily.
- Implement a CollisionWatcher and strategy to avoid collisions.
- Add logging (Keep track of movement and collisions & resolve (if applicable))
