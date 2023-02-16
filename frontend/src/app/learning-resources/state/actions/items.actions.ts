import { createActionGroup, props } from "@ngrx/store";
import { ItemEntity } from "../reducers/items.reducers";

export const itemsEvents = createActionGroup({
    source: 'Items Events',
    events: {}
})


export const itemsDocuments = createActionGroup({
    source: 'Items Documents',
    events: {
        items: props<{ payload: ItemEntity[] }>()
    }
})