namespace Everlore.Hero.Features.AddItem.Commands;

public class AddItemCommand(Action executeMethod, Func<bool> canExecuteMethod)
    : DelegateCommand(executeMethod, canExecuteMethod);

public class AddHeroCommand(Action executeMethod, Func<bool> canExecuteMethod)
    : DelegateCommand(executeMethod, canExecuteMethod);

public class AddSuperHeroCommand(Action executeMethod, Func<bool> canExecuteMethod)
    : DelegateCommand(executeMethod, canExecuteMethod);