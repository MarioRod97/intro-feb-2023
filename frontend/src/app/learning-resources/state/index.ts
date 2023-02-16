import { ActionReducerMap, createFeatureSelector } from "@ngrx/store";

export const featureName = "resources";

export interface FeatureInterface { }

export const reducers: ActionReducerMap<FeatureInterface> = {};

const selectFeature = createFeatureSelector<FeatureInterface>(featureName);
