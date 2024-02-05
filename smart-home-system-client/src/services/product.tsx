const baseUrl = 'https://localhost:7141';

const getAllProducts = async() => {
    const response = await fetch(`${baseUrl}/api/Product/getAll`);
    const data = await response.json();
    return data;
}

const ProductService = {
    getAllProducts,
}

export default ProductService;