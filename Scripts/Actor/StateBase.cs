public class StateBase {
    public bool canLeaveState = true;

    public ActorPlayer _actorPlayer;

    public StateBase(ActorPlayer actorPlayer) {
        _actorPlayer = actorPlayer;
    }
    public virtual void OnEnter() {
        
    }

    public virtual void OnUpdate(double delta) {

    }

    public virtual void OnPhysicsUpdate(double delta) {

    }

    public virtual void OnExit() {

    }
}