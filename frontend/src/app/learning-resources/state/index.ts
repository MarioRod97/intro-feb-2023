import { ActionReducerMap, createFeatureSelector } from "@ngrx/store";
import * as fromItems from './reducers/items.reducers';
export const featureName = "resources";

export interface FeatureInterface {
    items: fromItems.ItemState
}

export const reducers: ActionReducerMap<FeatureInterface> = {
    items: fromItems.reducer
};

const selectFeature = createFeatureSelector<FeatureInterface>(featureName);
