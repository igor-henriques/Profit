﻿namespace Profit.Domain.Commands.Ingredient.Create;

public sealed class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<IngredientDTO> _validator;

    public CreateIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<IngredientDTO> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request.Ingredient, cancellationToken);

        var ingredient = _mapper.Map<Entities.Ingredient>(request.Ingredient);

        await _unitOfWork.IngredientRepository.Add(ingredient);
        await _unitOfWork.SaveAsync(cancellationToken);
        return ingredient.Guid;
    }
}
