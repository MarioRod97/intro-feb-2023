import { createActionGroup, emptyProps } from "@ngrx/store";


export const counterEvents = createActionGroup({
    source: 'Counter Events',
    events: {
        'Count Incremented': emptyProps(),
        'Count Decremented': emptyProps(),
        'Count Reset': emptyProps()
    }
})