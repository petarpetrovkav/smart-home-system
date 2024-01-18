import React from 'react';
import logo from './logo.svg';
import './App.scss';
import {Route, Routes} from 'react-router-dom';
import {Card, Home, NotFound, Order, Product, Products, Register, Login, Contact} from './pages'
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
                    <Route path='/login' element={<Login/>}/>
                    <Route path='/register' element={<Register/>}/>
                    <Route path='*' element={<NotFound/>}/>
                </Route>
            </Routes>
        </div>
    );
}

export default App;
