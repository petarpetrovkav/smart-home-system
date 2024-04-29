import { createSlice } from '@reduxjs/toolkit';

const productsSlice = createSlice({
    name: 'products',
    initialState: [],
    reducers: {
        getAll: (state, action) => {
            return action.payload;
        }
    }
});

export const { getAll } = productsSlice.actions;

export default productsSlice.reducer;
