import React, {Suspense} from 'react';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import {Card, Home, NotFound, Order, Product, Products, Login, Contact} from './pages';
import Main from './layout/Main';
import { Provider } from 'react-redux';
import store from './store/store';

function App() {
  return (
    <div className="App">
      <Provider store={store}>
        <Suspense fallback={<div>Loading...</div>}>
        <Routes>
          <Route element={<Main/>}>
            <Route path='/' element={<Home/>}/>
            <Route path='/card' element={<Card/>}/>
            <Route path='/order' element={<Order/>}/>
            <Route path='/contact-us' element={<Contact/>}/>
            <Route path='/products' element={<Products/>}/>
            <Route path='/product/:id' element={<Product/>}/>
            <Route path='/register-login' element={<Login/>}/>
            <Route path='*' element={<NotFound/>}/>
          </Route>
        </Routes>
        </Suspense>
      </Provider>
    </div>
  );
}

export default App;
