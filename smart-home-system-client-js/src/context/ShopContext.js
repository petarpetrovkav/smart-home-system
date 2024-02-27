import React, {createContext, useEffect, useState} from "react";
import  all_product from "../assets/all_product"
import ProductService from "../services/product";

export const ShopContext = React.createContext(null);

const getDefaultCart = () => {
    let cart = {};
     for (let index = 0; index < 25; index++) {
         cart[index] = 0;
     }
    return cart;
}

const ShopContextProvider = (props) => {

    const [cartItems, setCartItems] = useState(getDefaultCart());
    const [allProducts, setAllProducts] = useState([]);

    useEffect(()=>{
        getData();
    },[])

    const getData = async () =>{
        const data = ProductService.getAllProducts();
        setAllProducts(data);
    }



    const addToCart = async (itemId) => {

    }
    const removeFromCart = async (itemId) => {

    }

    const getTotalCartAmount = () =>{
        let totalAmount = 0;
        return totalAmount;
    }

    const getTotalCartItems = () => {
        let totalItem = 0;
        for (const item in cartItems) {
            if(cartItems[item]>0){
                totalItem+= cartItems[item];
            }
        }
        return totalItem;
    }

    const contextValue = {getTotalCartItems, getTotalCartAmount, cartItems, allProducts, addToCart,removeFromCart};

    return(
        <ShopContext.Provider value={contextValue}>
            {props.children}
        </ShopContext.Provider>
    )
}

export default ShopContextProvider;