using Godot;

public class StateMachine {
    public StateBase CurrentSate { get; private set; }

    public bool TryEnterState(StateBase state) {
        if (CurrentSate != null) {            
            if (!CurrentSate.canLeaveState) {
                return false;
            }
            CurrentSate.OnExit();
        }

        CurrentSate = state;
        CurrentSate.OnEnter();

        return true;

    }
}