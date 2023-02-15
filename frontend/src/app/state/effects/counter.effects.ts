import { Injectable } from "@angular/core";
import { Actions, concatLatestFrom, ofType } from "@ngrx/effects";
import { createEffect } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { filter, map, tap } from "rxjs";
import { selectCounterFeature } from "..";
import { counterDocuments, counterEvents } from "../actions/counter.actions";
import { CounterState } from "../reducers/counter.reducer";

@Injectable()
export class CounterEffects {
    // this will turn counterEvents.counterEntered -> counterDocuments.counter || nothing
    loadCounterPrefs$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(counterEvents.counterEntered), // -> counterEntered Action
            map(() => localStorage.getItem('counter-data')), // string || null
            filter((storedStuff) => storedStuff != null),// stop here if there is nothing stored.
            map((storedStuff) => JSON.parse(storedStuff!) as CounterState),// { count: 1, by: 3} as CounterState
            map(payload => counterDocuments.counter({ payload }))
        )
    }, { dispatch: false })

    saveCounterPrefs$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(counterEvents.countBySet, counterEvents.countDecremented, counterEvents.countIncremented, counterEvents.countReset),
            concatLatestFrom(() => this.store.select(selectCounterFeature)),
            tap(([_, data]) => localStorage.setItem('counter-data', JSON.stringify(data)))
        )
    }, { dispatch: false })

    // logItall$ = createEffect(() => {
    //     return this.actions$.pipe(
    //         tap(a => console.log(`Got an action of type ${a.type}`))

    //     )
    // }, { dispatch: false })

    constructor(private actions$: Actions, private store: Store) { }
}