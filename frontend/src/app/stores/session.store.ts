import { patchState, signalStore, withHooks, withMethods, withProps, withState } from "@ngrx/signals";

import { Session, SessionSummary } from "../models/session";
import { inject } from "@angular/core";
import { SessionService } from "../services/session.service";
import { addEntity, removeAllEntities, setEntities, updateEntity, withEntities } from '@ngrx/signals/entities';

export const SessionStore = signalStore(
    { providedIn: 'root' },
    withEntities<SessionSummary>(),
    withProps(() => ({
        sessionService: inject(SessionService)
    })),
    withState({
        status: 'idle' as 'idle' | 'loading' | 'error'
    }),
    withMethods((store) => ({
        reloadList ()  {
            patchState(store, { status: 'loading' });
            patchState(store, removeAllEntities());
            store.sessionService.getSessions().subscribe({
                next: (sessions) => {
                    patchState(store, setEntities(sessions || []));
                    patchState(store, { status: 'idle' });
                },
                error: (error) => {
                    console.error('Error loading sessions:', error);
                    patchState(store, { status: 'error' });
                }
            });
        },
    })),
    withHooks({
        onInit: (store) => {
          store.reloadList();
        }
    })
);
