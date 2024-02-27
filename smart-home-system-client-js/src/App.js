import React from 'react';
import './App.css';
import {Route, Routes} from 'react-router-dom';
import {Card, Home, NotFound, Order, Product, Products, Login, Contact} from './pages'
import Main from './layout/Main'

function App() {
  return (
    <div className="App">
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
    </div>
  );
}

export default App;
