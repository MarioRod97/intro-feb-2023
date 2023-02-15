// tell typescript about it

import { createReducer, on } from "@ngrx/store";
import { counterEvents } from "../actions/counter.actions";

export interface CounterState {
    current: number;
}

// What should this have when the application starts up? 

const initialState: CounterState = {
    current: 0
}

// write a function that is responsible for this branch of the application state.
// this function gets a read-only copy of the current state, and any actions that have been dispatched
// and it can return a new state.

export const reducer = createReducer(initialState,
    on(counterEvents.countIncremented, (currentState) => ({ ...currentState, current: currentState.current + 1 })),
    on(counterEvents.countDecremented, (s) => ({ ...s, current: s.current - 1 })),
    on(counterEvents.countReset, () => initialState)
);