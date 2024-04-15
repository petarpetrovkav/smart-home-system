import React, {createContext, useEffect, useState} from "react";
import  all_product from "../assets/all_product"
import ProductService from "../services/product";
import CartService from "../services/cart";
import RegisterLoginService from "../services/registerlogin";

export const ShopContext = React.createContext(null);

const getDefaultCart = () => {
    let cart = {};
     for (let index = 0; index < 25; index++) {
         cart[index] = 0;
     }
    return cart;
}

const ShopContextProvider = (props) => {
    const baseUrl = 'https://localhost:7141';

    const [cartItems, setCartItems] = useState(getDefaultCart());
    const [allProducts, setAllProducts] = useState([]);

    useEffect(()=>{
        getAllCartProduct();
    },[])


    const getAllCartProduct = async () =>{
        const data = await CartService.getAllCartProduct();
        setAllProducts(data);
/*        getTotalCartItems(data);
        getTotalCartAmount(data);*/
    }

    const addToCart = async (productId) =>{
        let responseData;
        if(localStorage.getItem('auth-token')){
            await fetch(`${baseUrl}/api/Cart/AddItem`,{
                method: 'POST',
                headers:{
                    'Content-Type':'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('auth-token')}`,
                },
                body: JSON.stringify({"ProductId":productId, "Quantity": 1, "ShoppingCartId": "" }),
            })
                .then((response)=> response.json())
                .then((data)=>responseData=data).catch((data)=> responseData=data);
            return responseData;
        }
    }


    const getTotalCartAmount = () =>{
        let totalAmount = 0;
        for (const item in allProducts) {
            totalAmount += allProducts[item].stockQuantity == 1 ? allProducts[item].price : allProducts[item].price * allProducts[item].stockQuantity;
        }
        return totalAmount;
    }

    const getTotalCartItems = () => {
        let totalItem = 0;
        for (const item in allProducts) {
            console.log(allProducts[item]);
            totalItem += allProducts[item].stockQuantity;
        }
        return totalItem;
    }

    const contextValue = {getTotalCartItems, getTotalCartAmount, getAllCartProduct, cartItems, allProducts, addToCart/*, updateQuantity, removeFromCart*/};

    return(
        <ShopContext.Provider value={contextValue}>
            {props.children}
        </ShopContext.Provider>
    )
}

export default ShopContextProvider;