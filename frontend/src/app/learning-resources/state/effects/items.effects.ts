import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { map, switchMap } from "rxjs";
import { itemsDocuments } from "../actions/items.actions";
import { learingResourcesEvents } from "../actions/learning-resources.actions";
import { ItemEntity } from "../reducers/items.reducers";


@Injectable()
export class ItemsEffects {

    loadItemsOnFeatureEntered$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(learingResourcesEvents.entered),
            switchMap(() => this.client.get<ItemResponseFromServer>('http://localhost:1337/resources')
                .pipe(
                    map(response => response.items), // { items: []} => []
                    map(payload => itemsDocuments.items({ payload }))
                )

            )
        )
    })

    constructor(private actions$: Actions, private client: HttpClient) { }
}

type ItemResponseFromServer = {
    items: ItemEntity[]
}