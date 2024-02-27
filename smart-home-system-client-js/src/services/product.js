const baseUrl = 'https://localhost:7141';

const getAllProducts = async() => {
    const response = await fetch(`${baseUrl}/api/Product/getAll`);
    return  await response.json();
}

const getProductById = async(id) => {
    const response = await fetch(`${baseUrl}/api/Product/getProductById/${id}`);
    return  await response.json();
}

const ProductService = {
    getAllProducts,
    getProductById,
}

export default ProductService;