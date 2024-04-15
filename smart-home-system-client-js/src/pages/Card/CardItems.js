import React, {useContext, useRef} from "react";

import './CardItems.scss'
import {ShopContext} from "../../context/ShopContext";
import remove_icon from '../../assets/images/cart_cross_icon.png';
import CartService from "../../services/cart"


export default function CardItems() {
    const messageRefDelete = useRef(null);
    const messageRefUpdate = useRef(null);
   /* const {getTotalCartAmount, allProducts, removeFromCart, updateQuantity} = useContext(ShopContext);*/
    const {getTotalCartAmount, allProducts} = useContext(ShopContext);

    const updateQuantity = async (itemId, shoppingCartId, value) => {
        try {
            const response = await CartService.updateQuantity(itemId, shoppingCartId, value);
            messageRefUpdate.current.innerText = response.responseMessage;
            if (response.isValid) {
                messageRefUpdate.current.style.display = 'block';
                setTimeout(() => {
                    messageRefUpdate.current.style.display = 'none';
                }, 3000);
            }
        }
        catch (error){
            console.error('Error', error);
        }
    }

    const removeFromCart = async (itemId, shoppingCartId) => {
        try{
            const response = await CartService.removeToCart(itemId, shoppingCartId);
            messageRefDelete.current.innerText = response.responseMessage;
            if(response.isValid){
                messageRefDelete.current.style.display = 'block';
                setTimeout(() => {
                    messageRefDelete.current.style.display = 'none';
                }, 3000);
            }
        }catch (error){
            console.error('Error', error);
        }
    }


    /*    const deleteProduct = async(productId,shoppingCartId) => {
            try{
                const response = await removeFromCart(productId, shoppingCartId);
                messageRefDelete.current.innerText = response.responseMessage;
                if(response.isValid){
                    messageRefDelete.current.style.display = 'block';
                    setTimeout(() => {
                        messageRefDelete.current.style.display = 'none';
                    }, 5000);
                }
            }catch (error){
                console.error('Error', error);
            }
        }*/

 /*   const updateProduct = async(productId,shoppingCartId, value) => {
        try{
            const response = await updateQuantity(productId, shoppingCartId, value);
            messageRefUpdate.current.innerText = response.responseMessage;
            if (response.isValid) {
                messageRefUpdate.current.style.display = 'block';
                setTimeout(() => {
                    messageRefUpdate.current.style.display = 'none';
                }, 3000);
            }
        } catch (error){
            console.error('Error', error);
        }
    }*/

    return (
        <div id="card">
            <div className="cart-items">
                <div className="cart-items-format-main">
                    <p>Products</p>
                    <p>Title</p>
                    <p>Price</p>
                    <p>Quantity</p>
                    <p>Total</p>
                    <p>Remove</p>
                </div>
                <div ref={messageRefDelete} style={{display: 'none'}}></div>
                <div ref={messageRefUpdate} style={{display: 'none'}}></div>
                <hr/>
                {allProducts.map((item,index)=>{
                        return <div key={item.productId}>
                            <div className="cart-items-format cart-items-format-main">
                                <img src={item.imageUrl} alt="" className="cart-icon-product-icon"/>
                                <p>{item.productName}</p>
                                <p>{item.price}</p>
                                <input type="number" className='cart-items-quantity' value={item.stockQuantity}
                                    onChange={(e) => updateQuantity(item.productId, item.shoppingCartId, e.target.value)}
                                />
                                <p>${item.price*item.stockQuantity}</p>
                                <img src={remove_icon} className="cart-items-remove-icon" onClick={() => {removeFromCart(item.productId,item.shoppingCartId)}} alt=""/>
                            </div>
                            <hr/>
                        </div>
                })}
                <div className="cart-items-down">
                    <div className="cart-items-total">
                        <h1>Cart Totals</h1>
                        <div>
                            <div className="cart-items-total-item">
                                <p>Subtotal</p>
                                <p>${getTotalCartAmount()}</p>
                            </div>
                            <hr/>
                            <div className="cart-items-total-item">
                                <p>Shipping Free</p>
                                <p>Free</p>
                            </div>
                            <hr/>
                            <div className="cart-items-total-item">
                                <h3>Total</h3>
                                {/*<h3>${getTotalCartAmount}</h3>*/}
                            </div>
                        </div>
                        <button>PROCEED TO CHECKOUT</button>
                    </div>
                    <div className="cart-item-promo-code">

                    </div>
                </div>
            </div>
        </div>
    );
}