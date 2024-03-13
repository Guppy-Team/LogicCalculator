import { configureStore } from '@reduxjs/toolkit';
import expressionReducer from './expressionSlice';
import resultReducer from './resultSlice';

const store = configureStore({
  reducer: {
    expression: expressionReducer,
    result: resultReducer,
  },
});

export default store;
