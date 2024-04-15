const baseUrl = 'https://localhost:7141';

/*const addToCart = async(productId) => {
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
           return responseData.isValid;
     }
}*/

const updateQuantity = async (productId, shoppingCartId, quantity)=>{
    let responseData;

    if(localStorage.getItem('auth-token')){
        await fetch(`${baseUrl}/api/Cart/Update`,{
            method: 'PUT',
            headers:{
                'Content-Type':'application/json',
                'Authorization': `Bearer ${localStorage.getItem('auth-token')}`,
            },
            body: JSON.stringify({"ProductId":productId, "Quantity": quantity, "ShoppingCartId":shoppingCartId}),
        })
            .then((response)=> response.json())
            .then((data)=>responseData=data).catch((data)=> responseData=data);
        return responseData;
    }
}

const removeToCart = async (productId, shoppingCartId) =>{
    let responseData;

    if(localStorage.getItem('auth-token')){
        await fetch(`${baseUrl}/api/Cart/Delete`,{
            method: 'DELETE',
            headers:{
                'Content-Type':'application/json',
                'Authorization': `Bearer ${localStorage.getItem('auth-token')}`,
            },
            body: JSON.stringify({"ProductId":productId, "ShoppingCartId":shoppingCartId}),
        })
            .then((response)=> response.json())
            .then((data)=>responseData=data).catch((data)=> responseData=data);
        return responseData;
    }
}

const getAllCartProduct = async() => {
    let responseData;

    if(localStorage.getItem('auth-token')){
       await fetch(`${baseUrl}/api/Cart/GetAllProductByShoppingCart`,{
            method: 'GET',
        }).then((response)=> response.json()).then((data)=>responseData=data).catch((data)=> responseData=data);
        return responseData;
    }
}



const CartService = {
  /*  addToCart,*/
    getAllCartProduct,
    removeToCart,
    updateQuantity,
}

export default CartService;