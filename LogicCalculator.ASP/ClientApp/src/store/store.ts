import { configureStore } from '@reduxjs/toolkit';
import calculatorReducer from './calculatorSlice';

const store = configureStore({
  reducer: {
    calculator: calculatorReducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      immutableCheck: false,
      serializableCheck: false,
    }),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;