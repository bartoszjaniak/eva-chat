import { patchState, signalStore, withHooks, withProps, withState } from "@ngrx/signals";

import { Session, SessionSummary } from "../models/session";
import { inject } from "@angular/core";
import { SessionService } from "../services/session.service";
import { addEntity, setEntities, updateEntity, withEntities } from '@ngrx/signals/entities';

export const SessionStore = signalStore(
    { providedIn: 'root' },
    withEntities<SessionSummary>(),
    withProps(() => ({
        sessionService: inject(SessionService)
    })),
    withState({
        status: 'idle' as 'idle' | 'loading' | 'error'
    }),
    withHooks({
        onInit: async (store) => {
            patchState(store, { status: 'loading' });
            try {
                const sessions = await store.sessionService.getSessions().toPromise();
                patchState(store, setEntities(sessions || []));
                patchState(store, { status: 'idle' });
            } catch (error) {
                console.error('Error loading sessions:', error);
                patchState(store, { status: 'error' });
            }
        }
    })
);
